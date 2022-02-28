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
    public class UsersController : ControllerBase
    {
        UserRepository repository = new UserRepository();
        dev_MyntradbContext context = new dev_MyntradbContext();

        [HttpGet]
        public IEnumerable<User> get()
        {
            return repository.getUser().ToList();
        }

           [HttpPost] 
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                context.Users.Add(user);
                context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Registeration succesfully"
                });
            }
        }



    }
}

