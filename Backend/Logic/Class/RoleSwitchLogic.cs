using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Class
{
    ///<inheritdoc/>
    public class RoleSwitchLogic : IRoleSwitchLogic
    {
        /// <summary>
        /// Repository for the roleswitch table.
        /// </summary>
        public IRoleSwitchRepository roleSwitchRepository;

        /// <summary>
        /// Creates a new instance of the RoleSwitch logic.
        /// </summary>
        /// <param name="dbPassword">The password used for connecting to the db</param>
        public RoleSwitchLogic(string dbPassword)
        {
            this.roleSwitchRepository = new RoleSwitchRepository(dbPassword);
        }

        ///<inheritdoc/>
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

        ///<inheritdoc/>
        public IQueryable<RoleSwitch> GetAllRoleSwitchRequests()
        {
            return this.roleSwitchRepository.GetAll();
        }

        ///<inheritdoc/>
        public RoleSwitch GetOne(int id)
        {
            return this.roleSwitchRepository.GetOne(id);
        }

        /// <summary>
        /// Determines if a username has already requested a role switch.
        /// </summary>
        /// <param name="userName">The username we want to check.</param>
        /// <returns>True of false</returns>
        public bool AlreadyAppliedForRole(string userName)
        {
            return (this.roleSwitchRepository.GetOne(userName) == false);
        }

        /// <summary>
        /// Logic to switch roles of user if everything is in order.
        /// </summary>
        /// <param name="roleName">The name of the role a user wants to join into.</param>
        /// <param name="userName">The username who wants a new role.</param>
        /// <returns>True if successful, false if not</returns>
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
