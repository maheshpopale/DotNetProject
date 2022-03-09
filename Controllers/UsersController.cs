using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyntraClone.Helper;
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
        UserRepository _repository = new UserRepository();
        dev_MyntradbContext context = new dev_MyntradbContext();

        //get users
        [HttpGet]
        public IEnumerable<User> get()
        {
            return _repository.getUsers().ToList();
        }

        //get user by ID
        [Route("user/{id:int}")]
        public User get(int id)
        {
            return _repository.getUserDetails(id);
        }
        //Add New User
        [HttpPost] 
        public IActionResult Create([FromBody] User user)
        {

            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                user.Password = EncDscPassword.EncryptPassword(user.Password);
                context.Users.Add(user);
                context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Registeration succesfully"
                });
            }
        }

        //Delete User
        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data =_repository;
            if (data == null)
            {
                return NotFound();
            }
            _repository.delete(id);
            return Ok();
        }



    }
}

