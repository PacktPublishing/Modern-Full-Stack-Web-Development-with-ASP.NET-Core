using System.Diagnostics;
using System.Security.Claims;
using Authentication.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Authentication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)

        {

            var user = AuthenticateUser(username, password);

            if (user != null)

            {

                var claims = new List<Claim>

                {

                    new Claim(ClaimTypes.Name, user.Name),

                    new Claim(ClaimTypes.Role, user.Role),

                };



                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties { IsPersistent = true };



                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,

                    new ClaimsPrincipal(claimsIdentity), authProperties);



                return RedirectToAction("Index", "Home");

            }



            return View();

        }

        private User AuthenticateUser(string username, string password)
        {
            //Add your custom logic for auth

            return null;
        }

        private string GenerateJwtToken(string username, List<Claim> claims)

        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKeyHere"));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);



            var token = new JwtSecurityToken(

                issuer: "YourIssuer",

                audience: "YourAudience",

                claims: claims,

                expires: DateTime.Now.AddHours(3),

                signingCredentials: credentials

            );



            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
