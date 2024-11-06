using DotNetApi.Model.Entities;

namespace DotNetApi.Utili
{
    public class ProductList
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Category> Categories { get; set; }
    }
}
