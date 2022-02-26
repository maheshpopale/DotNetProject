using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyntraClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyntraClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        ProductsRepository _repository = new ProductsRepository();

        [HttpGet]
        //[Authorize]
        public IEnumerable<Product> Get()
        {
            return _repository.getProducts().ToList();

        }
        [HttpGet("{id}")]
        public Product getProductById(int id)
        {
            return _repository.getProductById(id);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            //var id = _repository.getCount();
            //user.Id = id + 1;
            if (ModelState.IsValid)
            {
                //Guid obj = Guid.NewGuid();
                // employee.Id = obj();
                _repository.AddProduct(product);
                return Ok(product);
            }
            return BadRequest();
        }




        /*
        // PUT api/<Employee1Controller>/5



        [HttpPut]
        public IActionResult Edit([FromBody] Employee employee)
        {
        if (ModelState.IsValid)
        {
        repository.UpdateEmployee(employee);
        return Ok();
        }
        return BadRequest();
        }




        // DELETE api/<Employee1Controller>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
        var data = repository.GetEmployeeId(id);
        if (data == null)
        {
        return NotFound();
        }
        repository.DeleteEmployeeRecord(id);
        return Ok();
        }*/


    }
}
