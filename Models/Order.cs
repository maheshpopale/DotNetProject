using System;
using System.Collections.Generic;

#nullable disable

namespace MyntraClone.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
