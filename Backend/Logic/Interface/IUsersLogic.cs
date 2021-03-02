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
        bool CreateUser(Users user);
        bool DeleteUser(int userId);

        bool UpdateUser(int oldId, Users newUser);
        public bool Login(Login login);

    }
}
