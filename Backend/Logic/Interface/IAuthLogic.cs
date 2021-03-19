using Microsoft.AspNetCore.Identity;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interface
{
    public interface IAuthLogic
    {
        IdentityUser GetOneUser(string userId);
        IQueryable<IdentityUser> GetAllUsers();
        Task<string> CreateUser_debug(Login login);
        bool DeleteUser(string userId);

        bool UpdateUser(string oldId, IdentityUser newUser);
        Task<TokenModel> LoginUser(Login login);
    }
}
