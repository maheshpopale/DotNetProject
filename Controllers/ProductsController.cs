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
        //get products List
        public IEnumerable<Product> Get()
        {
            return _repository.getProducts().ToList();

        }

        //get product by Id
        [HttpGet("{id}")]
        public Product getProductById(int id)
        {
            return _repository.getProductById(id);
        }

        //get products by Category Id
        [Route("categories/{id:int}")]
        public Product getProductByCategory(int id)
        {
            return _repository.getProductByCategory(id);
        }

        //add new product
        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.AddProduct(product);
                return Ok(product);
            }
            return BadRequest();
        }

        //update an existing product details
        [HttpPut]
        public IActionResult Edit([FromBody] Product product)
        {
        if (ModelState.IsValid)
        {
        _repository.UpdateProduct(product);
        return Ok();
        }
        return BadRequest();
        }

        //Delete product
        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
        var data = _repository.getProductById(id);
        if (data == null)
        {
        return NotFound();
        }
        _repository.delete(id);
        return Ok();
        }


    }
}
