using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IRoleSwitchRepository : IRepository<RoleSwitch, int>
    {
        bool GetOne(string userName);
    }
}
