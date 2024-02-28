
using Microsoft.EntityFrameworkCore;
using OrderEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDataAccess.Context
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext() { }

        public OrderDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=TRN00089\\SQLEXPRESS;Initial Catalog=BookSaleOrder;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }


        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderBook> OrderBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderBook>().HasKey(u => new { u.Order_Id, u.Book_Id });



            modelBuilder.Entity<Order>()
           .Property(o => o.Id)
           .UseIdentityColumn();

        }
    }
}
