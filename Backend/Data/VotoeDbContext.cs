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
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //var builder = new SqlConnectionStringBuilder("server=95.111.254.24;database=projektmunka;user=projektmunka");
                var builder = new SqlConnectionStringBuilder("server=95.111.254.24;database=projektmunka_teszt;user=projektmunka");

                builder.Password = ConnectionStrinPassword;
                optionsBuilder.UseSqlServer(builder.ConnectionString);
            }
        }


        public virtual DbSet<Models.Users> Users { get; set; }
        public virtual DbSet<Models.OneVote> OneVote { get; set; }
        public virtual DbSet<Models.AllVotes> AllVotes { get; set; }
        public virtual DbSet<Models.VotingRight> VotingRight { get; set; }
        public virtual DbSet<Models.UserType> UserType { get; set; }
        //public IQueryable<AllVotes> AllVotes { get; set; } //TODO: Delete when db is updated with AllVotes
        //public IQueryable<OneVote> OneVote { get; set; } //TODO: Delete when db is updated with OneVote
    }
}
