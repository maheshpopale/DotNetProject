using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyntraClone.Helper;
using MyntraClone.Models;
using MyntraDbContext;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyntraClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        UserRepository _repository = new UserRepository();
        dev_MyntradbContext context = new dev_MyntradbContext();
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] User user)
        {
            //var User = repository.checkLogin(user);
            var result = context.Users.ToList();
            var status = false;
            var tokenString = "";
            var userId = 0;
            foreach (var item in result)
            {
                if (item.Email == user.Email && EncDscPassword.DecryptPassword(item.Password) == user.Password)
                {
                    status = true;
                    userId = item.Id;
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44362",
                    audience: "https://localhost:44362",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                    );
                    tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    break;
                }
                else
                {
                    status = false;



                }
            }
            if (status)
                return Ok(new { tokenString, userId });
            else
                return Unauthorized();
        }
    }
}
        
  
