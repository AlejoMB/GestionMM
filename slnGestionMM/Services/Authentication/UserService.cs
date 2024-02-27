using Domain;
using Domain.Entities.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Services.Authentication
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly GestionDbContext db;
        private readonly IConfiguration _config;

        public UserService(IOptions<AppSettings> appSettings, GestionDbContext _db, IConfiguration config)
        {
            _appSettings = appSettings.Value;
            db = _db;
            _config = config;
        }

        public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model)
        {
            var user = await db.Users.SingleOrDefaultAsync(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = await generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await db.Users.Where(x => x.isActive == true).ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            return await db.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<string>> GetUserRolesById(int id)
        {
            return db.RolesUser.Where(x => x.UserId == id).Select(x => x.Rol.Name).Distinct().ToList();
        }

        public async Task<User> GetUser(string userName)
        {
            return db.Users.FirstOrDefault(x => x.Username == userName);
        }

        public async Task<User?> AddAndUpdateUser(User userObj)
        {
            bool isSuccess = false;
            if (userObj.Id > 0)
            {
                var obj = await db.Users.FirstOrDefaultAsync(c => c.Id == userObj.Id);
                if (obj != null)
                {
                    // obj.Address = userObj.Address;
                    obj.FirstName = userObj.FirstName;
                    obj.LastName = userObj.LastName;
                    db.Users.Update(obj);
                    isSuccess = await db.SaveChangesAsync() > 0;
                }
            }
            else
            {
                await db.Users.AddAsync(userObj);
                isSuccess = await db.SaveChangesAsync() > 0;
            }

            return isSuccess ? userObj : null;
        }

        // helper methods
        private async Task<string> generateJwtToken(User user)
        {
            

            /*var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("Id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };*/
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["AppSettings:Secret"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new List<Claim>();
            userClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            AddRolesToClaim(userClaims, user.Id);
            //    new Claim(ClaimTypes.Name, user.Name),
            //    new Claim(ClaimTypes.Email, user.Email),
            //    new Claim(ClaimTypes.Role, user.Role)
            //};
            var token = new JwtSecurityToken(
            //issuer: _config["Jwt:Issuer"],
            //audience: _config["Jwt:Audience"],
            claims: userClaims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials
            );



            return new JwtSecurityTokenHandler().WriteToken(token);
            
        }

        private async void AddRolesToClaim(List<Claim> userClaims, int userId)
        {
            var roles = await GetUserRolesById(userId);

            if (roles.Count == 0)
            {
                return;
            }

            foreach (var role in roles)
            {
                if (userClaims.Count(c => c.Value.Equals(role)) > 0)
                {
                    continue;
                }

                userClaims.Add(new Claim(ClaimTypes.Role, role));
            }
        }
    }
}
