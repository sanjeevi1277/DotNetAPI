using DotNetApi.DTO;
using DotNetApi.Interface;
using DotNetApi.Model.Data;
using DotNetApi.Model.Entities;
using DotNetApi.Utili;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DotNetApi.Repository
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _dbcontext;
        public ProductService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<string> CreateProduct(ProductDTO product)
        {
            Product products = new Product();
            //var a = JsonConvert.SerializeObject(product);
            //products.ProductName = JsonConvert.SerializeObject(product);
            products.ProductName = product.ProductName;
            products.ProductImageUrl = product.ProductImageUrl;
            products.CategoryId = product.CategoryId;

            _dbcontext.Product.Add(products);
            await _dbcontext.SaveChangesAsync();
            //await _dbcontext.Entry(products).Reference(p => p.Category).LoadAsync();
            return "Product Added Successfully!";

        }

        public async Task<ActionResult<IEnumerable<ProductList>>> GetAllProducts()
        {

            //var products= await _dbcontext.Product.
            //     Include(a => a.Category).ToListAsync();
            // return products;

            return await _dbcontext.Product
           .Include(p => p.Category)
           .Select(p => new ProductList
           {
               Id = p.Id,
               ProductName = p.ProductName,
               ProductImageUrl = p.ProductImageUrl,
               CategoryName = p.Category.Name,
           }).ToListAsync();


        }
        public async Task<ActionResult<IList<ProductList>>> GetProductByID(int id)
        {
            var category = await _dbcontext.Category.ToListAsync();
            //var product = await _dbcontext.Product.Where(a => a.Id == id).FirstAsync();

            //var productDto = JsonConvert.DeserializeObject<ProductDTO>(product.ProductName);

            return await _dbcontext.Product
          .Include(p => p.Category)
          .Where(p => p.Id == id)
          .Select(p => new ProductList
          {
              Id = p.Id,
              ProductName = p.ProductName,
              ProductImageUrl = p.ProductImageUrl,
              CategoryName = p.Category.Name,
              Categories = category
          })
          .ToListAsync();
        }


    }
}
