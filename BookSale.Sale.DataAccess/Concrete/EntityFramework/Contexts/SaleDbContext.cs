using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSale.Sale.Entities.Concrete;


namespace BookSale.Sale.DataAccess.Concrete.EntityFramework.Contexts
{
    public class SaleDbContext : DbContext
    {
        public SaleDbContext() { }

        public SaleDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=TRN00089\\SQLEXPRESS;Initial Catalog=BookSaleWeek8CaseDB;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderBook> OrderBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderBook>().HasKey(u => new { u.Order_Id, u.Book_Id });

            modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .UseIdentityColumn();

            modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasDefaultValue("User");

            modelBuilder.Entity<Book>()
            .Property(b => b.Id)
            .UseIdentityColumn();

            modelBuilder.Entity<Book>()
            .Property(b => b.Price)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Category>()
           .Property(c => c.Id)
           .UseIdentityColumn();

            modelBuilder.Entity<Order>()
           .Property(o => o.Id)
           .UseIdentityColumn();

        }
    }
}
