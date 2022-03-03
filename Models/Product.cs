using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MyntraClone.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int? ProductQuantity { get; set; }
        public decimal? ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string Image { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime?UpdatedAt { get; set; }
        public int? CategoryId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual Category? Category { get; set; }
    }
}
