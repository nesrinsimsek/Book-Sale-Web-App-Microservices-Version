using BookSale.IoC;
using BookSale.Sale.DataAccess.Concrete.EntityFramework.Contexts;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Microsoft.OpenApi.Models;
using BookSale.Sale.Api;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SaleDbContext>(options => options.
    UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
builder.Services.AddAutoMapper(typeof(MappingConfig));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sale Api", Version = "v1" });
});
//builder.Services.AddMediatR(typeof(Program));

DependencyContainer.RegisterServices(builder.Services);

//builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<SaleDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sale Api V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();

