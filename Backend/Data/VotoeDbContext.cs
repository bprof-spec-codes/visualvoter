using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class VotoeDbContext : DbContext
    {
        private readonly string ConnectionStrinPassword;

        public VotoeDbContext(string connectpw)
        {
            this.ConnectionStrinPassword = connectpw;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new SqlConnectionStringBuilder("server=95.111.254.24;database=projektmunka;user=projektmunka");
                builder.Password = ConnectionStrinPassword;
                optionsBuilder.UseSqlServer(builder.ConnectionString);
            }
        }


        public virtual DbSet<Models.Users> Users { get; set; }
        //public virtual DbSet<Models.OneVote> OneVote { get; set; }
        //public virtual DbSet<Models.AllVotes> AllVotes { get; set; }
    }
}
