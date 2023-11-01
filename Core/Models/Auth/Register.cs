using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Auth
{
    public class Register
    {
        [Required(ErrorMessage = "The " + nameof(Username) + " field is important")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "The " + nameof(Username) + " field is important")]
        public string FirstMidName { get; set; } = null!;
        [Required(ErrorMessage = "The " + nameof(Username) + " field is important")]
        public string LastName { get; set; } = null!;

        [EmailAddress]
        [Required(ErrorMessage = "The " + nameof(Email) + " field is important")]
        public string Email { get; set; } = null!;

        [PasswordPropertyText]
        [Required(ErrorMessage = "The " + nameof(Password) + " field is important")]
        public string Password { get; set; } = null!;
    }
}
