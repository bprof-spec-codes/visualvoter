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
            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public IQueryable<Users> GetAll()
        {
            return this.db.Users;
        }

        public Users GetOne(int userId)
        {
            return this.db.Users.Where(x => x.UserID == userId).FirstOrDefault();
        }
    }
}
