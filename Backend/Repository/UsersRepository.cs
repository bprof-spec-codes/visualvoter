using Models;
using Data;
using System;
using System.Linq;

namespace Repository
{
    public class UsersRepository : IUsersRepository
    {
        private VotoeDbContext db;

        public UsersRepository()
        {
            this.db = new VotoeDbContext();
        }

        public void CreateUser(Users user)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Users> GetAll()
        {
            throw new NotImplementedException();
        }

        public Users GetOne(int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
