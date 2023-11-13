using Core.Models.Auth;

namespace Core
{
    public interface IAuthentication
    {
        Task<(bool, string)> RegisterAsync(Register register, string role);
        Task<(bool, string)> AuthenticateAsync(Login login);
    }
}
