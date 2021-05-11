using Microsoft.AspNetCore.Identity;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interface
{
    /// <summary>
    /// Logic for auth related functionality
    /// </summary>
    public interface IAuthLogic
    {

        /// <summary>
        /// Returns a single user
        /// </summary>
        /// <param name="userId">Id of the user</param>
        /// <param name="email">Email address of the user</param>
        /// <returns>A single IdentityUser object</returns>
        IdentityUser GetOneUser(string userId, string email);

        /// <summary>
        /// Gets all the users
        /// </summary>
        /// <returns>A collection of all the suers</returns>
        IQueryable<IdentityUser> GetAllUsers();

        /// <summary>
        /// DEBUG ONLY
        /// Creates a single user, used only for debugging, as user registration is not part of our project.
        /// </summary>
        /// <param name="login">Login object, containing the login detals of the user to be created</param>
        /// <returns>'Ok', if the method successfully completed</returns>
        Task<string> CreateUser_debug(Login login);
        /// <summary>
        /// Deletes a single user
        /// </summary>
        /// <param name="userId">ID of the user to be deleted</param>
        /// <returns>'Ok', if the method successfully completed</returns>
        Task<string> DeleteUser(string userId);

        /// <summary>
        /// Deletes a single user
        /// </summary>
        /// <param name="inUser">IdentityUser object of the user to deleted</param>
        /// <returns>"Ok", if the method successfully completed</returns>
        Task<string> DeleteUser(IdentityUser inUser);

        /// <summary>
        /// Updates the specified user
        /// </summary>
        /// <param name="oldId">The original id of the user to be updated</param>
        /// <param name="newUser">IdentityUser object, with the updated fields</param>
        /// <returns>"Ok", if the method successfully completed</returns>
        Task<string> UpdateUser(string oldId, IdentityUser newUser);

        /// <summary>
        /// Method used to verify a login. 
        /// </summary>
        /// <param name="login">Login object, containing the login details</param>
        /// <returns>A TokenModel in case of a successful login, containing the JWT token of the logged in user</returns>
        Task<TokenModel> LoginUser(Login login);

        /// <summary>
        /// Returns all the roles which have been auto-generated upon a vote creation
        /// </summary>
        /// <returns>A collection of IdentityRoles</returns>
        IEnumerable<IdentityRole> GetAllRoles();

        /// <summary>
        /// Check if a specified user has the role provided in the parameter.
        /// </summary>
        /// <param name="user">The user to be checked</param>
        /// <param name="role">Name of the role to be checked</param>
        /// <returns>True, if the user has the role, false if not</returns>
        bool HasRole(IdentityUser user, string role);

        /// <summary>
        /// Gets all the roles a specified user has
        /// </summary>
        /// <param name="user">IdentityUser object, to be checked</param>
        /// <returns>A collection of roles that the user has</returns>
        IEnumerable<string> GetAllRolesOfUser(IdentityUser user);
        /// <summary>
        /// Used for assigning multiple roles to a single user
        /// </summary>
        /// <param name="user">The user to used</param>
        /// <param name="roles">Collection of toles that are to be assigned to the user</param>
        /// <returns>True, if it was successful</returns>
        bool AssignRolesToUser(IdentityUser user, List<string> roles);

        /// <summary>
        /// Creates a role if it doesn't exist yet
        /// </summary>
        /// <param name="name">The name of the role to be created</param>
        /// <returns>True, if it was successful</returns>
        Task<bool> CreateRole(string name);

        /// <summary>
        /// Creates a new role for a newly created vote, then assigns it to every user, who has the roles that were provided in the parameter
        /// </summary>
        /// <param name="roles">The holders of these roles will be assigned the newly created role</param>
        /// <returns>The name of the newly created role</returns>
        Task<string> RoleCreationForNewVote(IList<string> roles);

        /// <summary>
        /// Gets all the users that have the role specified in parameter
        /// </summary>
        /// <param name="roleId">The id of the role to be searched</param>
        /// <returns>Collection of users that match the criteria</returns>
        Task<List<IdentityUser>> GetAllUsersOfRole(string roleId);

        /// <summary>
        /// Checks if a user has a specified ole
        /// </summary>
        /// <param name="userName">username of the user to be checked</param>
        /// <param name="role">The role we're looking for</param>
        /// <returns>True, if the user has the role, false if not</returns>
        Task<bool> HasRoleByName(string userName, string role);
    }
}
