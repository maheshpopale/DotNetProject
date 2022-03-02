using Microsoft.EntityFrameworkCore;
using MyntraClone.Controllers;
using MyntraDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyntraClone.Models
{
    public class ordersRepository
    {
        dev_MyntradbContext context = new dev_MyntradbContext();

        //getLatestOrderId
        public Order getOrderId()
        {
            var lastSequence = context.Orders.OrderByDescending(p => p.Id).FirstOrDefault();
            return lastSequence;
        }
        //Getting All Orders
        public IEnumerable<OrderMaster> getOrders()
        {
            try
            {
                var allOrders = (from orders in context.Orders
                                 join od in context.OrderDetails on orders.Id equals od.OrderId
                                 join p in context.Products on od.ProductId equals p.Id
                                 orderby orders.Id
                                 select new OrderMaster
                                 {
                                     orderId = orders.Id,
                                     orderDate = (DateTime)orders.OrderDate,
                                     userId = (int)orders.UserId,
                                     firstName = od.FirstName,
                                     lastName = od.LastName,
                                     email = od.Email,
                                     address = od.Address,
                                     city = od.City,
                                     zip = od.Zip,
                                     productName = p.ProductName,
                                     paymentMode = od.PaymentMode,
                                     productQuantity = (int)od.ProductQuantity,
                                     productPrice = (decimal)od.ProductPrice,
                                     productSize = od.Size,
                                     orderStatus=od.orderStatus
                                 }).ToList();
                return allOrders;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
                            
        }
        //Update Order
        public IEnumerable<OrderDetail> UpdateOrder(int id)
        {
            var orders=context.OrderDetails.ToList()
                          .Where(x => x.OrderId==id);
            foreach (var order in orders)
            {
                order.orderStatus = "Accepted";
                context.Entry(order).State = EntityState.Modified;
            }

            context.SaveChanges();
            return orders;

        }

        public  IEnumerable<OrderDetail> deleteOrder(int id)
        {
            var orders = context.OrderDetails.ToList()
                         .Where(x => x.OrderId == id);
            foreach(var order in orders)
            {
                context.OrderDetails.Remove(order);
                context.SaveChanges();
                
            }
            return orders;
        }

        //Adding an Order
        public void addOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        //Adding Order Details
        public IEnumerable<OrderDetail> AddOrderDetails(OrderDetail order)
        {
            var orders=(IEnumerable<OrderDetail>)context.OrderDetails.Add(order);
            context.SaveChanges();
            return orders;


        }

        //getting Order Details by User ID
        public IEnumerable<OrderMaster> getOrdersById(int id)
        {
            var userOrders = (from orders in context.Orders
                              join od in context.OrderDetails
                              on orders.Id equals od.OrderId
                              join p in context.Products on od.ProductId equals p.Id
                              where orders.UserId == id
                              select new OrderMaster
                              {
                                  orderId = orders.Id,
                                  orderDate = (DateTime)orders.OrderDate,
                                  userId = (int)orders.UserId,
                                  firstName = od.FirstName,
                                  lastName = od.LastName,
                                  email = od.Email,
                                  address = od.Address,
                                  city = od.City,
                                  zip = od.Zip,
                                  productName = p.ProductName,
                                  paymentMode = od.PaymentMode,
                                  productQuantity = (int)od.ProductQuantity,
                                  productPrice = (decimal)od.ProductPrice,
                                  productSize = od.Size,
                                  orderStatus=od.orderStatus
                              }
                           ).ToList();
            return userOrders;
        }
    }
}
