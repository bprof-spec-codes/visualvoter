using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class VotoeDbContext : IdentityDbContext<IdentityUser>
    {
        private readonly string ConnectionStrinPassword;

        public VotoeDbContext(string connectpw)
        {
            this.ConnectionStrinPassword = connectpw;
            this.Database.EnsureCreated();
        }
        public VotoeDbContext()
        {
            this.Database.EnsureCreated();
        }

        public VotoeDbContext(DbContextOptions<VotoeDbContext> opt) : base(opt)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Eredeti db
                //var builder = new SqlConnectionStringBuilder("server=95.111.254.24;database=projektmunka;user=projektmunka");

                //Teszt db
                //var builder = new SqlConnectionStringBuilder("server=95.111.254.24;database=projektmunka_teszt;user=projektmunka");
               // builder.Password = ConnectionStrinPassword;
                
                //Localdb
                var builder = new SqlConnectionStringBuilder(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VotOEDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                
                optionsBuilder.UseSqlServer(builder.ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Models.Users> Users { get; set; }
        public virtual DbSet<Models.OneVote> OneVote { get; set; }
        public virtual DbSet<Models.AllVotes> AllVotes { get; set; }
        public virtual DbSet<Models.VotingRight> VotingRight { get; set; }
        public virtual DbSet<Models.UserType> UserType { get; set; }
    }
}
