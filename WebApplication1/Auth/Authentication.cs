using Core;
using Core.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Auth
{
    public class Authentication : IAuthentication
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public Authentication(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<(bool, string)> RegisterAsync(Register register, string role)
        {
            var exists = await _userManager.FindByEmailAsync(register.Email);
            if (exists is not null)
                return (false, "User already exists");

            User user = new()
            {
                SecurityStamp = Guid.NewGuid().ToString(),

                Email = register.Email,
                UserName = register.Username,

                FirstMidName = register.FirstMidName,
                LastName = register.LastName
            };

            var createUser = await _userManager.CreateAsync(user, register.Password);

            if (!createUser.Succeeded)
                return (false, "Fatal error");

            //replace
            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));

            await _userManager.AddToRoleAsync(user, role);

            return (true, "Success");
        }

        public async Task<(bool, string)> AuthenticateAsync(Login login)
        {
            var user = await _userManager.FindByNameAsync(login.Username);
            if (user is null)
                return (false, "Invalid Username " + login.Username);

            if (!await _userManager.CheckPasswordAsync(user, login.Password))
                return (false, "Invalid Password");

            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in userRoles)
                authClaims.Add(new Claim(ClaimTypes.Role, role));

            string token = GenerateToken(authClaims);

            return (true, token);
        }

        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:Key"]));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Authentication:Issuer"],
                Audience = _configuration["Authentication:Audience"],
                Expires = DateTime.Now.AddMinutes(1),
                SigningCredentials = new(signingKey, SecurityAlgorithms.HmacSha256),
                Subject = new(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
