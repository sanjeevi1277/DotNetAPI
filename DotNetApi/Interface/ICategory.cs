using DotNetApi.DTO;
using DotNetApi.Model.Entities;
using System.Threading.Tasks;

namespace DotNetApi.Interface
{
    public interface ICategory
    {
        Task<string> CreateCategory(CategoryDTO categoryDTO);
        Task<ActionResult<Category>> UpdateCategory(int id, Category category);
    }
}
