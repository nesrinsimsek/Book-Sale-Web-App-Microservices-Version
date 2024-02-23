using Microsoft.EntityFrameworkCore;
using Product.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.DataAccess.Concrete.Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext() { }

        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=TRN00089\\SQLEXPRESS;Initial Catalog=BookSaleProduct;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }


        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Book>()
            .Property(b => b.Id)
            .UseIdentityColumn();

            modelBuilder.Entity<Book>()
            .Property(b => b.Price)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Category>()
           .Property(c => c.Id)
           .UseIdentityColumn();

        }
    }
}
