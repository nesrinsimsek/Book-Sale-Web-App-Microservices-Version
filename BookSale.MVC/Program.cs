using BookSale.MVC.Helpers;
using BookSale.MVC.Services.Abstract;
using BookSale.MVC.Services.Concrete;
using BookSale.Sale.Business.Abstract;
using BookSale.Sale.Business.Concrete;
using BookSale.Sale.MVC;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using IBookService = BookSale.MVC.Services.Abstract.IBookService;
using ICategoryService = BookSale.MVC.Services.Abstract.ICategoryService;
using IOrderService = BookSale.MVC.Services.Abstract.IOrderService;
using IOrderBookService = BookSale.MVC.Services.Abstract.IOrderBookService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpClient<IBookService, BookService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddHttpClient<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddHttpClient<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddHttpClient<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddHttpClient<IOrderBookService, OrderBookService>();
builder.Services.AddScoped<IOrderBookService, OrderBookService>();

builder.Services.AddScoped<ICartService, CartManager>();
builder.Services.AddScoped<ICartSessionHelper, CartSessionHelper>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(options =>
              {
                  options.Cookie.HttpOnly = true;
                  options.LoginPath = "/Auth/Login";
                  options.AccessDeniedPath = "/Auth/AccessDenied";
                  options.SlidingExpiration = true;
              });
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
