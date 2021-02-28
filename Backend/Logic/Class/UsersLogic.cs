using Models;
using Repository;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Logic
{
    public class UsersLogic : IUsersLogic
    {
        public IUsersRepository usersRepo;

        public UsersLogic(string dbPassword)
        {
            this.usersRepo = new UsersRepository(dbPassword);
        }

        public void CreateUser(Users user)
        {
            user.UserPassword = hashPw(user.UserPassword);
            this.usersRepo.Add(user);
        }

        public void DeleteUser(int userId)
        {
            this.usersRepo.Delete(userId);
        }

        public IQueryable<Users> GetAllUsers()
        {
            return this.usersRepo.GetAll();
        }

        public Users GetOneUser(int userId)
        {
            return this.usersRepo.GetOne(userId);
        }

        public void UpdateUser(int oldId, Users newUser)
        {
            var oldUserPwdHash = GetOneUser(oldId).UserPassword;
            if (newUser.UserPassword != oldUserPwdHash && String.IsNullOrWhiteSpace(newUser.UserPassword))// if pass was changed..
            {
                newUser.UserPassword = hashPw(newUser.UserPassword); //..use new hashed pass
            }
            else
            {
                newUser.UserPassword = oldUserPwdHash; // else keep the old hash
            }
            this.usersRepo.Update(oldId, newUser);
        }

        public string hashPw(string input) //TODO: Should salt, needs one more db field to store salt
        {

            var sha512 = new SHA512Managed();
            var bytes = UTF8Encoding.UTF8.GetBytes(input);
            var hash = sha512.ComputeHash(bytes);
            return Convert.ToBase64String(hash);

        }
    }
}
