﻿using Logic.Interface;
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

        public AuthLogic(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }


        public IQueryable<IdentityUser> GetAllUsers()
        {
            return userManager.Users;
        }
        public IdentityUser GetOneUser(string id)
        {
            return userManager.Users.Where(x => x.Id == id).SingleOrDefault();
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
               await userManager.AddToRoleAsync(user, "HALLGATO");
            }
            return user.UserName;
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

        public IEnumerable<IdentityRole> getAllRoles()
        {
            return roleManager.Roles.ToList();
        }

        public bool hasRole(IdentityUser user, string role)
        {
            if (userManager.IsInRoleAsync(user, role).Result)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<string> getAllRolesOfUser(IdentityUser user)
        {
            return userManager.GetRolesAsync(user).Result.ToList();
        }

        public bool assignRolesToUser(IdentityUser user, List<string> roles)
        {
            userManager.AddToRolesAsync(user, roles).Wait();
            return true;
        }

        public bool createRole(string name)
        {
            var test = roleManager.Roles;
            ;
            var querry = roleManager.Roles.Where(x => x.NormalizedName == name.ToUpper()).SingleOrDefault();
            ;
            if (roleManager.Roles.Where(x => x.NormalizedName == name.ToUpper()).SingleOrDefault() == null)
            {
                return false;
            }
            roleManager.CreateAsync(new IdentityRole { Id = Guid.NewGuid().ToString(), Name = name, NormalizedName = name.ToUpper() });
            return true;
        }
    }
}
