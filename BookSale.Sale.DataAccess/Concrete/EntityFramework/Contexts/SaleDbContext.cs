using BookSale.Sale.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookSale.Sale.DataAccess.Concrete.EntityFramework.Contexts
{
    public class SaleDbContext : IdentityDbContext<IdentityUser>
    {
        public SaleDbContext(DbContextOptions options) : base(options)
        {
        }
        //public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
           .Property(b => b.Id)
           .UseIdentityColumn();

            modelBuilder.Entity<Category>()
           .Property(c => c.Id)
           .UseIdentityColumn();

            modelBuilder.Entity<Order>()
           .Property(d => d.Id)
           .UseIdentityColumn();

        }
    }
}
