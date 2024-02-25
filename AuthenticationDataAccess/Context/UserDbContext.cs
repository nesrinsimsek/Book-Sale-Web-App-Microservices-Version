using AuthenticationEntity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationDataAccess.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext() { }

        public UserDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=TRN00089\\SQLEXPRESS;Initial Catalog=BookSaleUser;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            

            modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .UseIdentityColumn();

            modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasDefaultValue("User");

          

        }
    }
}
