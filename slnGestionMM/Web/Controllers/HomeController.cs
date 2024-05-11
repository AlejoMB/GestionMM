using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Domain.Models;
using NuGet.Common;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.HttpResults;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private GestionDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, GestionDbContext dbContext)
        {
            _dbContext = dbContext;
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

        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> AddAuthorization(string token)
        {
            /*var credentialAsString = Encoding.UTF8.GetString(Convert.FromBase64String(token.Substring(6)));

            var credentials = credentialAsString.Split(":");
            if (credentials?.Length != 2)
            {
                return Unauthorized("Unauthorized");
            }*/

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);



            /*var username = credentials[0];
            var password = credentials[1];

            var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return Unauthorized("Authentication failed");
            }

            if (username != "test@fake.com" && password != "subscribe")
            {
                return Unauthorized("Authentication failed");
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, username)
            };

            SetClaimRoles(user.Id, claims);*/

            var identity = new ClaimsIdentity(jwtToken.Claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(identity);
            //HttpContext.User = claimsPrincipal;*/
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

            HttpContext.Items["UserIdentity"] = claimsPrincipal;

            return RedirectToAction("Index", "Inventario");
        }

        private void SetClaimRoles(int userId, List<Claim> claims)
        {
            var roles = _dbContext.RolesUser.Include(r => r.Rol).Where(r => r.UserId == userId).Select(r => r.Rol.Name);

            if (roles == null)
            {
                return;
            }

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
        }
    }
}
