using Models;
using Data;
using System;
using System.Linq;

namespace Repository
{
    public class UsersRepository : IUsersRepository
    {
        private VotoeDbContext db;

        public UsersRepository(string dbPassword)
        {
            this.db = new VotoeDbContext(dbPassword);
        }

        public void CreateUser(User user)
        {
            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public IQueryable<User> GetAll()
        {
            return this.db.Users;
        }

        public User GetOne(int userId)
        {
            return this.db.Users.Where(x => x.UserID == userId).FirstOrDefault();
        }
    }
}
