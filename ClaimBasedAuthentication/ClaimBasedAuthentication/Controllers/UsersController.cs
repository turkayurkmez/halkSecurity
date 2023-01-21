using ClaimBasedAuthentication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ClaimBasedAuthentication.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel userLoginModel)
        {
            var user = new FakeUsers().ValidateUser(userLoginModel.UserName, userLoginModel.Password);

            if (user != null)
            {
                //Kimliğini kanıtladın. Şimdi, ziyaretçi kartı alma zamanı
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, userLoginModel.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                return Redirect("/");
            }
            return BadRequest(new { message = "Hatalı kullanıcı adı veya şifre" });




        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }


    }

    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
    }

    public class FakeUsers
    {
        private List<User> users = new List<User>
        {
            new User{ Id=1, UserName="turkay", Password="123", Email="turkay@halkbank.com.tr", Role="Admin" },
            new User{ Id=2, UserName="gokhantombul", Password="123", Email="gokhan.tombul@halkbank.com.tr", Role="Client" },
            new User{ Id=3, UserName="alikavak", Password="123", Email="ali.kavak@halkbank.com.tr", Role="Editor" },

        };

        public User ValidateUser(string username, string password)
        {
            return users.FirstOrDefault(p => p.UserName == username && p.Password == password);
        }
    }
}
