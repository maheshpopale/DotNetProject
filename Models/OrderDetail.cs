using System;
using System.Collections.Generic;

#nullable disable

namespace MyntraClone.Models
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PaymentMode { get; set; }
        public int? ProductId { get; set; }
        public int? ProductQuantity { get; set; }
        public decimal? ProductPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? OrderId { get; set; }
        public string Size { get; set; }
        public string orderStatus { get; set; }
        public virtual Order order { get; set; }
        public virtual Product product { get; set; }
    }
}
