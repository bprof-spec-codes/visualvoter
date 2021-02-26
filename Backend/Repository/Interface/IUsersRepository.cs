using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    interface IUsersRepository : IRepository<Users,int>
    {
        void CreateUser(Users user);
        new Users GetOne(int UserId);
        new IQueryable<Users> GetAll();
    }
}
