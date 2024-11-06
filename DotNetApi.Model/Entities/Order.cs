using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetApi.Model.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public double TotalAmount { get; set; }
        public int OrderStatus { get; set; }
        public int TotalQuantity { get; set; }
        public DateTime OrderedDate { get; set; } = DateTime.UtcNow;
        public ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
