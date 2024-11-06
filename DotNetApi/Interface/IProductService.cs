using DotNetApi.DTO;
using DotNetApi.Utili;
using System.Threading.Tasks;

namespace DotNetApi.Interface
{
    public interface IProductService
    {
        Task<string> CreateProduct(ProductDTO product);
        Task<ActionResult<IEnumerable<ProductList>>> GetAllProducts();
        Task<ActionResult<IList<ProductList>>> GetProductByID(int id);
    }
}
