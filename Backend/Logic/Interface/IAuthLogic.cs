﻿using Microsoft.AspNetCore.Identity;
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
        IdentityUser GetOneUser(string userId, string email);
        IQueryable<IdentityUser> GetAllUsers();
        Task<string> CreateUser_debug(Login login);
        Task<string> DeleteUser(string userId);
        Task<string> DeleteUser(IdentityUser inUser);
        Task<string> UpdateUser(string oldId, IdentityUser newUser);
        Task<TokenModel> LoginUser(Login login);
        IEnumerable<IdentityRole> GetAllRoles();
        bool HasRole(IdentityUser user, string role);
        IEnumerable<string> GetAllRolesOfUser(IdentityUser user);
        bool AssignRolesToUser(IdentityUser user, List<string> roles);
        Task<bool> CreateRole(string name);
        Task<string> RoleCreationForNewVote(IList<string> roles);
        Task<List<IdentityUser>> GetAllUsersOfRole(string roleId);
        Task<bool> HasRoleByName(string userName, string role);
        //public void RemoveUserFromRole(string userName, string requiredRole);
    }
}
