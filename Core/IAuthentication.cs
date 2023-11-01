using Core.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IAuthentication
    {
        Task<(bool, string)> RegisterAsync(Register register, string role);
        Task<(bool, string)> AuthenticateAsync(Login login);

    }
}
