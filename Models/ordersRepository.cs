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
                                     productSize = od.Size
                                 }).ToList();
                return allOrders;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
                            
        }

        //Adding an Order
        public void addOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        //Adding Order Details
        public void AddOrderDetails(OrderDetail order)
        {
            context.OrderDetails.Add(order);
            context.SaveChanges();

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
                                  productSize = od.Size
                              }
                           ).ToList();
            return userOrders;
        }
    }
}
