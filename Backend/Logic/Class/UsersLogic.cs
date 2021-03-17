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
                //user.Token = null;
                this.usersRepo.Add(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
                newUser.UserPassword = sha256_hash(newUser.UserPassword); //..use new hashed pass
            }
            else
            {
                newUser.UserPassword = oldUserPwdHash; // else keep the old hash
            }
            
            try
            {
                //newUser.Token = null; //Token should never be updateable, only by login method.
                this.usersRepo.Update(oldId, newUser);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Login(Login login)
        {
            var user = this.usersRepo.GetOneByEmail(login.Email);
            string loginHash = sha256_hash(login.Password);
            if (loginHash == user.UserPassword.ToLower()) return true;//TODO: Isn't this a risk if 'var user' is null? What if user's querry returns is null, and the api endpoint recieves a null password to hash? I think this will pass as true.
            return false;
        }
        //public Users LoginToken(Login login)
        //{
        //    Guid g = Guid.NewGuid();
        //    var user = this.usersRepo.GetOneByEmail(login.Email);
        //    string loginHash = sha256_hash(login.Password);
        //    if (loginHash == user.UserPassword.ToLower()) 
        //    {
        //        user.Token = g;
        //        user.TokenDate = DateTime.Now;
        //        return user; //This user object's Token property is not null, unlike the user objects returned by getOne/getAll
        //    }
        //    return null;
        //}

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

        public IQueryable<UserType> GetAllUserTypes()
        {
            return this.usersRepo.GetAllUserTypes();
        }
    }
}
