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
    public class OrdersController : ControllerBase
    {
        ordersRepository _ordersRepository = new ordersRepository();
        public IEnumerable<OrderMaster> get()
        {
            var orders = _ordersRepository.getOrders();
            return orders;
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrderDetail order)
        {
            //var id = _repository.getCount();
            //user.Id = id + 1;
            if (ModelState.IsValid)
            {
                //Guid obj = Guid.NewGuid();
                // employee.Id = obj();
                _ordersRepository.AddOrderDetails(order);
                return Ok(order);
            }
            return BadRequest();
        }
    }
}
