using Logic.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Class
{
    ///<inheritdoc/>
    public class AuthLogic : IAuthLogic
    {
        UserManager<IdentityUser> userManager;
        RoleManager<IdentityRole> roleManager;
        private static Random random = new Random();

        /// <summary>
        /// Creates an instance of the AuthLogic
        /// </summary>
        /// <param name="userManager">AspNetCore.Identity UserManager</param>
        /// <param name="roleManager">AspNetCore.Identity RoleManager</param>
        public AuthLogic(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;

        }

        ///<inheritdoc/>
        public IQueryable<IdentityUser> GetAllUsers()
        {
            return userManager.Users;
        }
        ///<inheritdoc/>
        public IdentityUser GetOneUser(string id, string email)
        {
            if (id != null)
            {
                return userManager.Users.Where(x => x.Id == id).SingleOrDefault();
            }
            else if (email != null)
            {
                return userManager.Users.Where(x => x.Email == email).SingleOrDefault();
            }
            else
            {
                throw new ArgumentException();
            }
        }
        ///<inheritdoc/>
        public async Task<string> UpdateUser(string oldId, IdentityUser newUser)
        {
            await userManager.UpdateAsync(newUser);
            return "Success";
        }
        ///<inheritdoc/>
        public async Task<string> DeleteUser(string userId)
        {
            try
            {
                var selectedUser = userManager.Users.Where(x => x.Id == userId).Single();
                await userManager.DeleteAsync(selectedUser);
                return "Success";
            }
            catch (Exception)
            {
                return "Fail";
            }
        }
        ///<inheritdoc/>
        public async Task<string> DeleteUser(IdentityUser inUser)
        {
            try
            {
                await userManager.DeleteAsync(inUser);
                return "Success";
            }
            catch (Exception)
            {
                return "Fail";
            }

        }
        ///<inheritdoc/>
        public async Task<string> CreateUser_debug(Login model)
        {
            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Hallgató");
                return "OK";
            }
            return "NOT OK";
        }
        ///<inheritdoc/>
        public async Task<TokenModel> LoginUser(Login model)
        {
            var user = await userManager.FindByNameAsync(model.Email);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {


                var claims = new List<Claim>
                {
                  new Claim(JwtRegisteredClaimNames.Sub, model.Email),
                  new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                  new Claim(ClaimTypes.NameIdentifier, user.Id)
                };


                var roles = await userManager.GetRolesAsync(user);
                ;
                claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));


                var signinKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes("abc 123 970608 qwertzuiop"));

                var token = new JwtSecurityToken(
                  issuer: "http://www.security.org",
                  audience: "http://www.security.org",
                  claims: claims,
                  expires: DateTime.Now.AddMinutes(60),
                  signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );
                bool adminState = false;
                if (roles.Contains("Admin"))
                {
                    adminState = true;
                }

                bool editorState = false;
                if (roles.Contains("Editor"))
                {
                    editorState = true;
                }
                return new TokenModel
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    ExpirationDate = token.ValidTo,
                    isAdmin = adminState,
                    isEditor = editorState
                };
            }
            throw new ArgumentException("Login failed");
        }
        ///<inheritdoc/>
        public IEnumerable<IdentityRole> GetAllRoles()
        {
            return this.roleManager.Roles.Where(x => !x.Name.Contains("VOTECREATEDROLE")).ToList();
            //return roleManager.Roles.ToList();
        }
        ///<inheritdoc/>
        public bool HasRole(IdentityUser user, string role)
        {
            if (userManager.IsInRoleAsync(user, role).Result)
            {
                return true;
            }
            return false;
        }
        ///<inheritdoc/>
        public async Task<bool> HasRoleByName(string userName, string role)
        {
            var user = await this.userManager.FindByNameAsync(userName);
            if (userManager.IsInRoleAsync(user, role).Result || userManager.IsInRoleAsync(user, "Admin").Result)
            {
                return true;
            }
            return false;
        }
        ///<inheritdoc/>
        public IEnumerable<string> GetAllRolesOfUser(IdentityUser user)
        {
            return userManager.GetRolesAsync(user).Result.ToList();
        }
        ///<inheritdoc/>
        public bool AssignRolesToUser(IdentityUser user, List<string> roles)
        {
            IdentityUser selectedUser;
            if (!string.IsNullOrWhiteSpace(user.Id) && user.Id.ToLower() != "string")
            {
                selectedUser = GetOneUser(user.Id, null);
            }
            else
            {
                selectedUser = GetOneUser(null, user.Email);
            }
            //userManager.AddToRolesAsync(user, roles).Wait();
            userManager.AddToRolesAsync(selectedUser, roles).Wait();
            return true;
        }
        ///<inheritdoc/>
        public async Task<bool> CreateRole(string name)
        {
            var query = await this.roleManager.FindByNameAsync(name);
            //var query = roleManager.Roles.Where(x => x.NormalizedName == name.ToUpper()).SingleOrDefault();
            if (query != null)
            {
                return false;
            }
            roleManager.CreateAsync(new IdentityRole { Id = Guid.NewGuid().ToString(), Name = name, NormalizedName = name.ToUpper() }).Wait();
            return true;
        }
        ///<inheritdoc/>
        public async Task<string> RoleCreationForNewVote(IList<string> roles)
        {
            try
            {
                List<IdentityUser> users = new List<IdentityUser>();
                string newRoleNameForVote = "VOTECREATEDROLE-" + RandomString(16);
                await CreateRole(newRoleNameForVote);
                foreach (var roleId in roles)
                {
                    var usersOfRole = await this.GetAllUsersOfRole(roleId);
                    users.AddRange(usersOfRole);
                }
                foreach (var user in users)
                {
                    await this.userManager.AddToRoleAsync(user, newRoleNameForVote);
                }
                return newRoleNameForVote;
            }
            catch (Exception)
            {
                return "Fail";
            }
        }
        ///<inheritdoc/>
        public async Task<List<IdentityUser>> GetAllUsersOfRole(string roleId)
        {
            var users = await this.userManager.GetUsersInRoleAsync(roleId);
            return users.ToList();
        }

        private static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        ///<inheritdoc/>
        public async Task<string> RemoveUserFromRole(string userName, string requiredRole)
        {
            try
            {
                var user = await this.userManager.FindByNameAsync(userName);
                //var user = this.userManager.Users.Where(user => user.UserName == userName).SingleOrDefault();
                await this.userManager.RemoveFromRoleAsync(user, requiredRole);
                return "Success";
            }
            catch (Exception)
            {
                return "Fail";
            }
        }

        ///<inheritdoc/>
        public async Task<bool> SwitchRoleOfUser(string userName, string newRole)
        {
            try
            {
                var user = this.GetOneUser(null, userName);
                foreach (var role in this.GetAllRolesOfUser(user))
                {
                    await this.RemoveUserFromRole(user.UserName, role);
                }
                await this.userManager.AddToRoleAsync(user, newRole);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
