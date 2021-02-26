using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public interface IUsersLogic
    {
        User GetOneUser(int userId);
        IQueryable<User> GetAllUsers();
        void CreateUser(User user);
        bool DeleteUser(int userId);
    }
}
