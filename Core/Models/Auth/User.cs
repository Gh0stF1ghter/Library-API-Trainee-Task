using Microsoft.AspNetCore.Identity;

namespace Core.Models.Auth
{
    public class User : IdentityUser
    {
        public string FirstMidName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
