using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Auth
{
    public class User : IdentityUser
    {
        public string FirstMidName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
