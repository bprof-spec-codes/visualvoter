using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Logic for role switching
    /// </summary>
    public interface IRoleSwitchLogic
    {
        /// <summary>
        /// Deletes the specified role switch.
        /// </summary>
        /// <param name="id">The id of the roleswitch we want to delete.</param>
        /// <returns>True if successful, false if not</returns>
        bool Delete(int id);
        /// <summary>
        /// Returns all the role switches.
        /// </summary>
        /// <returns>A collection of all the roleSwitch</returns>
        IQueryable<RoleSwitch> GetAllRoleSwitchRequests();
        /// <summary>
        /// Returns one roleswitch.
        /// </summary>
        /// <param name="id">The id of the roleswitch we want to return.</param>
        /// <returns></returns>
        RoleSwitch GetOne(int id);
        /// <summary>
        /// Determines if a username has already requested a role switch.
        /// </summary>
        /// <param name="userName">The username we want to check.</param>
        /// <returns>True of false</returns>
        bool AlreadyAppliedForRole(string userName);
        /// <summary>
        /// Logic to switch roles of user if everything is in order.
        /// </summary>
        /// <param name="roleName">The name of the role a user wants to join into.</param>
        /// <param name="userName">The username who wants a new role.</param>
        /// <returns>True if successful, false if not</returns>
        bool RequestNewRole(string roleName, string userName);
    }
}
