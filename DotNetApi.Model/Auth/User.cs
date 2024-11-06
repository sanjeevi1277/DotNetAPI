using Microsoft.AspNetCore.Identity;

namespace DotNetApi.Model.Auth
{
    public class User : IdentityUser
    {
        public bool IsActive { get; set; }
    }
}
