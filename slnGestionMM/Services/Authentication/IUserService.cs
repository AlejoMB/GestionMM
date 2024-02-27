using Domain.Entities.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Authentication
{
    public interface IUserService
    {
        Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetById(int id);
        Task<User?> AddAndUpdateUser(User userObj);
        Task<List<string>> GetUserRolesById(int id);
        Task<User> GetUser(string userName);
    }
}
