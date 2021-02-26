using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public interface IUsersRepository : IRepository<User,int>
    {
        void CreateUser(User user);
        new User GetOne(int UserId);
        new IQueryable<User> GetAll();
    }
}
