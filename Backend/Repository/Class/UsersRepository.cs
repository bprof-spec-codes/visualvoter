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

        public void Add(Users user)
        {
            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public void Delete(int Id)
        {
            this.db.Users.Remove(this.GetOne(Id));
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

        public void Update(int oldId, Users element)
        {
            var oldUser = this.GetOne(oldId);
            oldUser = element;
            this.db.SaveChanges();
        }

        public Users GetOneByEmail(string email)
        {
            return this.db.Users.Where(x => x.Email == email).First();
        }
    }
}
