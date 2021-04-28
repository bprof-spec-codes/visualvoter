using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Class
{
    public class RoleSwitchLogic : IRoleSwitchLogic
    {
        public IRoleSwitchRepository roleSwitchRepository;

        public RoleSwitchLogic(string dbPassword)
        {
            this.roleSwitchRepository = new RoleSwitchRepository(dbPassword);
        }

        public bool Delete(int id)
        {
            try
            {
                this.roleSwitchRepository.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public RoleSwitch GetOne(int id)
        {
            return this.roleSwitchRepository.GetOne(id);
        }

        public bool AlreadyAppliedForRole(string userName)
        {
            return (this.roleSwitchRepository.GetOne(userName) == false);
        }

        public bool RequestNewRole(string roleName, string userName)
        {
            if (!AlreadyAppliedForRole(userName))
            {
                RoleSwitch newRoleSwitch = new RoleSwitch()
                {
                    RoleName = roleName,
                    UserName = userName
                };
                this.roleSwitchRepository.Add(newRoleSwitch);
                return true;
            }
            return false;
        }
    }
}
