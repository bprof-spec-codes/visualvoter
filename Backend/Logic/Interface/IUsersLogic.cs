using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public interface IUsersLogic
    {
        Users GetOneUser(int userId);
        IQueryable<Users> GetAllUsers();
        void CreateUser(Users user);
        bool DeleteUser(int userId);
    }
}
