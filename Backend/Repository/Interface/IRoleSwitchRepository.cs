using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    /// <summary>
    /// Repository for handling role switch related data.
    /// </summary>
    public interface IRoleSwitchRepository : IRepository<RoleSwitch, int>
    {
        /// <summary>
        /// Return a role switch based on the username.
        /// </summary>
        /// <param name="userName">The username we want to return.</param>
        /// <returns>True if 0, False if not</returns>
        bool GetOne(string userName);
    }
}
