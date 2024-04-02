using BookSale.MVC.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using System;

namespace BookSale.MVC.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<ApiRequest> Requests { get; set; }
        public DbSet<ApiResponse> Responses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApiRequest>()
                .OwnsOne(e => e.Data, d => d.ToJson());

            modelBuilder.Entity<ApiResponse>()
                .OwnsOne(e => e.Data, d => d.ToJson());
        }
    }
}
