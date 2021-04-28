using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public interface IRoleSwitchLogic
    {
        bool Delete(int id);
        IQueryable<RoleSwitch> GetAllRoleSwitchRequests();
        RoleSwitch GetOne(int id);
        bool AlreadyAppliedForRole(string userName);
        bool RequestNewRole(string roleName, string userName);
    }
}
