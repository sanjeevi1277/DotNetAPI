using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetApi.Model.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }


        [Required(ErrorMessage = "ProductName is required.")]
        [Column("ProductName", TypeName = "nvarchar(MAX)")]
        //[MaxLength(50)]
        // public string ProductName { get; set; } = "Default Product";

        public string ProductName { get; set; }
        //[Required]
        //public string ProductDescription { get; set; }
        [Required]
        public string ProductImageUrl { get; set; }

        [ForeignKey("Category")]

        public int CategoryId { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public Category Category { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }



    }
}
