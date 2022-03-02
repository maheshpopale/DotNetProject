using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyntraClone.Models;
using MyntraDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyntraClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        dev_MyntradbContext context = new dev_MyntradbContext();
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] Admin admin)
        {
            var status = false;
            var account = new Admin();
            //var User = repository.checkLogin(user);
            var result = context.Admins.ToList();
            foreach(var admin1 in result)
            {
                if (admin1.Email == admin.Email && admin1.Password == admin.Password)
                    status = true;
            }
            return Ok(status);
        }
        }
}
