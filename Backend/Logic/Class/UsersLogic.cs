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

        public void CreateUser(Users user)
        {
            this.usersRepo.Add(user);
        }

        public bool DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Users> GetAllUsers()
        {
            return this.usersRepo.GetAll();
        }

        public Users GetOneUser(int userId)
        {
            return this.usersRepo.GetOne(userId);
        }
    }
}
