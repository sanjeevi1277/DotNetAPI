using DotNetApi.DTO;
using DotNetApi.Interface;
using DotNetApi.Model.Data;
using DotNetApi.Model.Entities;
using System.Threading.Tasks;

namespace DotNetApi.Repository
{
    public class CategoryService : ICategory
    {
        private readonly ApplicationDbContext _dbcontext;
        public CategoryService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<string> CreateCategory(CategoryDTO categorydto)
        {
            Category category = new Category();
            category.Name = categorydto.CategoryName;
            _dbcontext.Category.Add(category);
            await _dbcontext.SaveChangesAsync();
            return "Category Created Successfully!";
        }
        public async Task<ActionResult<Category>> UpdateCategory(int id, Category category)
        {
            var categoryEntity = await _dbcontext.Category.FindAsync(id);
            if (categoryEntity == null)
            {
                return null;
            }
            categoryEntity.Name = category.Name;

            _dbcontext.Category.Update(categoryEntity);
            await _dbcontext.SaveChangesAsync();
            return categoryEntity;
        }
    }
}
