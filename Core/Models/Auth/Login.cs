using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Auth
{
    public class Login
    {
        [Required(ErrorMessage = "Invalid input")]
        public string Username { get; set; } = null!;

        [PasswordPropertyText]
        [Required(ErrorMessage = "Invalid input")]
        public string Password { get; set; } = null!;
    }
}
