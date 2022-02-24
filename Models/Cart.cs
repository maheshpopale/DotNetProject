using System;
using System.Collections.Generic;

#nullable disable

namespace MyntraClone.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int? ProductPrice { get; set; }
        public int? ProductQuantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
