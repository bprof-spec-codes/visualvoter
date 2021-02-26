using Models;
using Repository;
using System;
using System.Linq;

namespace Logic
{
    public class UsersLogic : IUsersLogic
    {
        public IUsersRepository usersRepo;

        public UsersLogic(string dbPassword)
        {
            this.usersRepo = new UsersRepository(dbPassword);
        }

        public void CreateUser(User user)
        {
            this.usersRepo.CreateUser(user);
        }

        public bool DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetAllUsers()
        {
            return this.usersRepo.GetAll();
        }

        public User GetOneUser(int userId)
        {
            return this.usersRepo.GetOne(userId);
        }
    }
}
