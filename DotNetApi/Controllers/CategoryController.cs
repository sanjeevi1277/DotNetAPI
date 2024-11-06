using DotNetApi.DTO;
using DotNetApi.Interface;
using DotNetApi.Model.Entities;
using System.Threading.Tasks;

namespace DotNetApi.Controllers.AuthenticateAPI
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _category;
        public CategoryController(ICategory category)
        {
            _category = category;
        }
        [HttpPost("createCategory")]

        public async Task<string> CreateCategory(CategoryDTO categorydto)
        {
            var category = await _category.CreateCategory(categorydto);
            // _dbcontext.Category.Add(category);
            //await _dbcontext.SaveChangesAsync();
            return category;
        }




        [HttpPut("Updateproduct/{id}")]
        public async Task<ActionResult<Category>> UpdateCategory(int id, [FromBody] Category category)
        {
            var categoryEntity = await _category.UpdateCategory(id, category);

            if (categoryEntity == null)
            {
                return NotFound("Category Not Found");

            }
            //var categoryEntity = await _dbcontext.Category.FindAsync(id);
            //if (categoryEntity == null)
            //{
            //    return NotFound("Category Not Found");
            //}
            //categoryEntity.Name = category.Name;

            //_dbcontext.Category.Update(categoryEntity);
            //await _dbcontext.SaveChangesAsync();
            //return Ok($"Updated" + category.Name );
            return Ok($"Updated {category.Name} Successfully");

        }
    }
}
