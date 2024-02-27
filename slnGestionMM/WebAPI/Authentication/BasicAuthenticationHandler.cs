using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Services.Authentication;

namespace WebAPI.Authentication
{
    public class BasicAuthenticationHandler //: AuthenticationHandler<AuthenticationSchemeOptions>
    {
        /*IUserService _userService;
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IUserService userService)
            : base(options, logger, encoder, clock)
        {
            _userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            string authorizationHeader = Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authorizationHeader))
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            if (!authorizationHeader.StartsWith("basic ", StringComparison.OrdinalIgnoreCase))
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            var token = authorizationHeader.Substring(6);
            var credentialAsString = Encoding.UTF8.GetString(Convert.FromBase64String(token));

            var credentials = credentialAsString.Split(":");
            if (credentials?.Length != 2)
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            var username = credentials[0];
            var password = credentials[1];

            var user = await _userService.GetUser(username);

            if(user == null)
            {
                return AuthenticateResult.Fail("Authentication failed");
            }

            if (username != "test@fake.com" && password != "subscribe")
            {
                return AuthenticateResult.Fail("Authentication failed");
            }

            List<Claim> claims = new List<Claim> 
            { 
                new Claim(ClaimTypes.NameIdentifier, username) 
            };

            SetClaimRoles(user.Id, claims);

            var identity = new ClaimsIdentity(claims, "Basic");
            var claimsPrincipal = new ClaimsPrincipal(identity);
            return AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, user.Id.ToString()));
        }

        private async void SetClaimRoles(int userId, List<Claim> claims)
        {
            var roles = await _userService.GetUserRolesById(userId);

            if (roles.Count == 0)
            {
                return;
            }

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
        }*/
    }
}
