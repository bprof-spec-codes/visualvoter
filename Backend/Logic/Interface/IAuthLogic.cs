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
        Task<string> DeleteUser(string userId);
        Task<string> DeleteUser(IdentityUser inUser);
        Task<string> UpdateUser(string oldId, IdentityUser newUser);
        Task<TokenModel> LoginUser(Login login);
        IEnumerable<IdentityRole> getAllRoles();
        bool hasRole(IdentityUser user, string role);
        IEnumerable<string> getAllRolesOfUser(IdentityUser user);
        bool assignRolesToUser(IdentityUser user, List<string> roles);
        bool createRole(string name);
    }
}
