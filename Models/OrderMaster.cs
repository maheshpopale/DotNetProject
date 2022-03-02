using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyntraClone.Models
{
    public class OrderMaster
    {
        public int orderId { get; set; }
        public DateTime orderDate { get; set; }
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string productName { get; set; }
        public string paymentMode { get; set; }
        public int productQuantity { get; set; }
        public decimal productPrice { get;set; }
        public string productSize { get; set; }
        public string orderStatus { get; set; }

        public static explicit operator OrderMaster(List<object> v)
        {
            throw new NotImplementedException();
        }
    }
}
