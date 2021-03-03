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
            user.UserPassword = sha256_hash(user.UserPassword);
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
            var output = this.usersRepo.GetAll();
            foreach (var item in output)
            {
                item.UserPassword = null;

            }
            return output;
        }

        public Users GetOneUser(int userId)
        {
            var output = this.usersRepo.GetOne(userId);
            output.UserPassword = null;
            return output;
            return this.usersRepo.GetOne(userId);
        }

        public bool UpdateUser(int oldId, Users newUser)
        {
            var oldUserPwdHash = GetOneUser(oldId).UserPassword;
            if (newUser.UserPassword != oldUserPwdHash && !String.IsNullOrWhiteSpace(newUser.UserPassword))// if pass was changed&is not null..
            {
                newUser.UserPassword = sha256_hash(newUser.UserPassword); //..use new hashed pass
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

        public bool Login(Login login)
        {
            var user = this.usersRepo.GetOneByEmail(login.Email);
            string loginHash = sha256_hash(login.Password);
            if (loginHash == user.UserPassword.ToLower()) return true;
            return false;
        }

        public static String sha256_hash(string value)
        {
            StringBuilder Sb = new StringBuilder();
            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }
    }
}
