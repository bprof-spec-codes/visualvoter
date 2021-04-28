using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    ///<inheritdoc/>
    public class RoleSwitchRepository : IRoleSwitchRepository
    {
        private VotoeDbContext db;
        /// <summary>
        /// Creates a new instance of the RoleSwitch repo
        /// </summary>
        /// <param name="dbPassword">Password for the db</param>
        public RoleSwitchRepository(string dbPassword)
        {
            this.db = new VotoeDbContext(dbPassword);
        }

        ///<inheritdoc/>
        public void Add(RoleSwitch element)
        {
            this.db.Add(element);
            this.db.SaveChanges();
        }

        ///<inheritdoc/>
        public void Delete(int element)
        {
            this.db.Remove(this.GetOne(element));
            db.SaveChanges();
        }

        ///<inheritdoc/>
        public IQueryable<RoleSwitch> GetAll()
        {
            return this.db.RoleSwitch;
        }

        ///<inheritdoc/>
        public RoleSwitch GetOne(int key)
        {
            var output = GetAll().Where(x => x.OneRoleSwitchID == key).SingleOrDefault();
            return output;
        }

        ///<inheritdoc/>
        public bool GetOne(string userName)
        {
            return (this.db.RoleSwitch.Count(x => x.UserName == userName) == 0);
        }

        ///<inheritdoc/>
        public void Update(int oldKey, RoleSwitch element)
        {
            var oldRoleSwitch = this.GetOne(oldKey);
            oldRoleSwitch = element;
            this.db.SaveChanges();
        }
    }
}
