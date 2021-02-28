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

        public bool CreateUser(Users user)
        {
            user.UserPassword = hashPw(user.UserPassword);
            try
            {
                this.usersRepo.Add(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            //this.usersRepo.Add(user);
        }

        public bool DeleteUser(int userId)
        {
            
            try
            {
                this.usersRepo.Delete(userId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            //this.usersRepo.Delete(userId);
        }

        public IQueryable<Users> GetAllUsers()
        {
            return this.usersRepo.GetAll();
        }

        public Users GetOneUser(int userId)
        {
            return this.usersRepo.GetOne(userId);
        }

        public bool UpdateUser(int oldId, Users newUser)
        {
            var oldUserPwdHash = GetOneUser(oldId).UserPassword;
            if (newUser.UserPassword != oldUserPwdHash && !String.IsNullOrWhiteSpace(newUser.UserPassword))// if pass was changed&is not null..
            {
                newUser.UserPassword = hashPw(newUser.UserPassword); //..use new hashed pass
            }
            else
            {
                newUser.UserPassword = oldUserPwdHash; // else keep the old hash
            }
            
            try
            {
                this.usersRepo.Update(oldId, newUser);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            //this.usersRepo.Update(oldId, newUser);
        }

        public string hashPw(string input) //TODO: Should salt, needs one more db field to store salt
        {

            var sha = new SHA1Managed();
            var bytes = UTF8Encoding.UTF8.GetBytes(input);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);

        }
    }
}
