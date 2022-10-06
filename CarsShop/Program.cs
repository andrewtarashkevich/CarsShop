using Microsoft.EntityFrameworkCore;
using CarsShop.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using CarsShop.BLL.DTO;
using CarsShop.BLL.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using CarsShop.DAL.Repositories;
using CarsShop.DAL.Entities;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<UserRepository, UserRepository>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<CarRepository, CarRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<Car>, CarRepository>();
builder.Services.AddDbContext<CarsShop.DAL.EF.UserContext>(options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CarsShopDB;Trusted_Connection=True;"));


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{    
    options.LoginPath = new PathString("/Authentication");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    options.SlidingExpiration = true;
    options.AccessDeniedPath = "/Authentication/Forbidden/";
});

try
{
    var app = builder.Build();

    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Users}/{action=Index}/{id?}");

    app.Run();
}
catch (Exception e)
{
    var a = e;
}
