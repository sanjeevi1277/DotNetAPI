using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetApi.Model.Entities
{
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public double Amount { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public Order Order { get; set; }
        public Product Product { get; set; }


    }
}
