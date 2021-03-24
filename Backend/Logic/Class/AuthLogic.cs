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
    public class AuthLogic : IAuthLogic
    {
        UserManager<IdentityUser> userManager;
        RoleManager<IdentityRole> roleManager;
        private static Random random = new Random();

        public AuthLogic(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            
        }


        public IQueryable<IdentityUser> GetAllUsers()
        {
            return userManager.Users;
        }
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
        public async Task<string> UpdateUser(string oldId, IdentityUser newUser)
        {
            await userManager.UpdateAsync(newUser);
            return "Success";
        }

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

                claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));


                var signinKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes("abc 123 970608 qwertzuiopőú"));

                var token = new JwtSecurityToken(
                  issuer: "http://www.security.org",
                  audience: "http://www.security.org",
                  claims: claims,
                  expires: DateTime.Now.AddMinutes(60),
                  signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );
                return new TokenModel
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    ExpirationDate = token.ValidTo
                };
            }
            throw new ArgumentException("Login failed");
        }

        public IEnumerable<IdentityRole> GetAllRoles()
        {
            return roleManager.Roles.ToList();
        }

        public bool HasRole(IdentityUser user, string role)
        {
            if (userManager.IsInRoleAsync(user, role).Result)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<string> GetAllRolesOfUser(IdentityUser user)
        {
            return userManager.GetRolesAsync(user).Result.ToList();
        }

        public bool AssignRolesToUser(IdentityUser user, List<string> roles)
        {
            var selectedUser = GetOneUser(user.Id, null);
            //userManager.AddToRolesAsync(user, roles).Wait();
            userManager.AddToRolesAsync(selectedUser, roles).Wait();
            return true;
        }

        public bool CreateRole(string name)
        {
            var query = roleManager.Roles.Where(x => x.NormalizedName == name.ToUpper()).SingleOrDefault();
            if (query != null)
            {
                return false;
            }
            roleManager.CreateAsync(new IdentityRole { Id = Guid.NewGuid().ToString(), Name = name, NormalizedName = name.ToUpper() }).Wait();
            return true;
        }

        public string RoleCreationForNewVote(IList<string> roles)
        {
            try
            {
                List<IdentityUser> users = new List<IdentityUser>();
                string newRoleNameForVote = "VOTECREATEDROLE-" + RandomString(16);
                CreateRole(newRoleNameForVote);
                foreach (var roleId in roles)
                {
                    users.Concat(this.GetAllUsersOfRole(roleId));
                }
                foreach (var user in users)
                {
                    this.userManager.AddToRoleAsync(user, newRoleNameForVote);
                }
                return newRoleNameForVote;
            }
            catch (Exception)
            {
                return "Fail";
            }
        }

        public IList<IdentityUser> GetAllUsersOfRole(string roleId)
        {
            return this.userManager.GetUsersInRoleAsync(roleId).Result.ToList();
        }

        private static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async void RemoveUserFromRole(string userName,string requiredRole)
        {
            var user = this.userManager.Users.Where(user => user.UserName == userName).SingleOrDefault();
            await this.userManager.RemoveFromRoleAsync(user, requiredRole);
        }
    }
}
