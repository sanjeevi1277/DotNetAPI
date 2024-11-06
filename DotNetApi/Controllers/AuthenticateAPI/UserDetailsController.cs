using DotNetApi.Model.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DotNetApi.Controllers.AuthenticateAPI
{
    [Route("api/userdetails")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;

        private readonly UserManager<IdentityUser> _userManager;

        public UserDetailsController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _dbcontext = dbContext;

        }

        [HttpGet("Alluser")]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _userManager.Users.ToListAsync();
            return Ok(new
            {
                user = users,
            });
        }
    }
}



