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
    public class CategoriesController : ControllerBase
    {
        CategoriesRepository _repository = new CategoriesRepository();
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _repository.getCategories().ToList();
        }

        //get Category by ID
        [HttpGet("{id}")]
        public Category getCategoryById(int id)
        {
            return _repository.getCategoryById(id);
        }

        public IActionResult Create([FromBody] Category newCategory)
        {
            //var id = _repository.getCount();
            //user.Id = id + 1;
            if (ModelState.IsValid)
            {
                //Guid obj = Guid.NewGuid();
                // employee.Id = obj();
                _repository.AddCategory(newCategory);
                return Ok(newCategory);
            }
            return BadRequest();
        }

          //Update Category
        [HttpPut]
        public IActionResult Edit([FromBody] Category category)
        {
        if (ModelState.IsValid)
        {
        _repository.UpdateCategory(category);
        return Ok();
        }
        return BadRequest();
        }




        // DELETE Category
        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
        var data = _repository.getCategoryById(id);
        if (data == null)
        {
        return NotFound();
        }
        _repository.delete(id);
        return Ok();
        }
}
}
