using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public interface IUsersRepository : IRepository<Users,int>
    {
        public Users GetOneByEmail(string email);

        public IQueryable<UserType> GetAllUserTypes();
    }
}
