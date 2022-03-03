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
        [Route("userorders/{id:int}")]
        public IEnumerable<OrderMaster> getOrdersById(int id)
        {
            var orders = _ordersRepository.getOrdersById(id);
            return orders;
        }

        [HttpPost,Route("order")]
        public IActionResult Create ([FromBody] Order order)
        {
            Order order1 = new Order();
            order1.OrderDate = new DateTime();
            order1.UserId = order.UserId;
            if (ModelState.IsValid)
            {
                //Guid obj = Guid.NewGuid();
                // employee.Id = obj();
                _ordersRepository.addOrder(order1);
                return Ok(order);
            }
            return BadRequest();
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
        [HttpGet, Route("orderid")]
        public Order getOrderId()
        {
            return _ordersRepository.getOrderId();
        }

        //Update order for status change of user's order
        [HttpGet("{id}")]
        public IEnumerable<OrderDetail> updateOrderStatus(int id)
        {
           return _ordersRepository.UpdateOrder(id);
         
        }
        //Delete Order

        [HttpDelete("{id}")]
        public IEnumerable<OrderDetail> DeleteConfirmed(int id)
        {
            return _ordersRepository.deleteOrder(id);
            
        }

    }
}
