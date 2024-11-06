
using DotNetApi.DTO;
using DotNetApi.Interface;
using DotNetApi.Model.Data;
using DotNetApi.Utili;
using System.Threading.Tasks;

//[Route("api/[controller]")]
[Route("api/products")]

[ApiController]
public class ProductController : ControllerBase
{
    private readonly ApplicationDbContext _dbcontext;
    private readonly IProductService _productService;

    public ProductController(ApplicationDbContext dbcontext, IProductService ser)
    {
        _dbcontext = dbcontext;
        _productService = ser;
    }

    [HttpPost("create")]
    public async Task<string> CreateProduct(ProductDTO product)
    {
        var products = await _productService.CreateProduct(product);
        //var products = _dbcontext.Product.Add(product);
        //await _dbcontext.SaveChangesAsync();
        return products;
    }
    [HttpGet("AllProducts")]
    public async Task<ActionResult<IEnumerable<ProductList>>> GetAllProducts()
    {
        var products = await _productService.GetAllProducts();
        if (products.Value == null)
        {
            return NotFound("No products available.");
        }

        return Ok(products);
    }
    //public async Task<IEnumerable<ProductList>> GetAllProducts()
    //{
    //    var products = await _productService.GetAllProducts();
    //    if (products.Value == null)
    //    {
    //        return Enumerable.Empty<ProductList>();
    //    }

    //    return products.Value;
    //}
    [HttpGet("getproduct/{id}")]
    public async Task<ActionResult<IList<ProductList>>> GetProductByID(int id)
    {
        var product = await _productService.GetProductByID(id);
        if (product.Value.Count == 0)
        {
            return NotFound("Not found");

        }
        return Ok(product);
    }



    //[HttpGet("product/{id}")]
    //public async Task<ActionResult<Product>> GetById(int id)
    //{
    //    var products = await _dbcontext.Product.Where(a => a.Id == id).ToListAsync();
    //    if (products.Any())
    //    {
    //        //return Ok(products);
    //        return Ok(new
    //        {
    //            message = "Deleted Successfully!!!",
    //            Id = id
    //        });

    //    }
    //    return BadRequest("No record found");
    //}


}

