using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BearerAuth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            if (userName == "turkay" && password == "123")
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email,"turkay.urkmez@dinamikzihin.com"),
                    new Claim(ClaimTypes.Role,"Admin")
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Bu gizli bir cumle"));
                var cryptoCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "api.halkbank.com.tr",
                    audience: "client.halkbank.com.tr",
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: cryptoCredential
                    );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

            }
            return BadRequest();

        }
    }
}
