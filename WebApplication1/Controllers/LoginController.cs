using Core;
using Core.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthentication _auth;

        public LoginController(IAuthentication authentication) => _auth = authentication;

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var (status, message) = await _auth.AuthenticateAsync(login);

            if (!status)
                return BadRequest(message);

            return Ok(message);
        }

        [HttpPost]
        [Route("reg")]
        public async Task<IActionResult> Register([FromBody] Register register)
        {
            var (status, message) = await _auth.RegisterAsync(register, Role.Admin);

            if (!status)
                return BadRequest(message);

            return CreatedAtAction(nameof(Register), register);
        }
    }
}
