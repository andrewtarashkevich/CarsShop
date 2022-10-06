using Microsoft.EntityFrameworkCore;
 using CarsShop.DAL.Entities;
using System.Numerics;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore.Design;
using AutoMapper;

namespace CarsShop.DAL.EF
{
    public class UserContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public UserContext()
        {

        }
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserContext).Assembly);
            #region UserSeed
            modelBuilder.Entity<User>().HasData(
                new User 
                {   UserID = 1, 
                    UserName = "UserName1",
                    UserPassword = "3453sdfd", 
                    UserBirthday = new DateTime(2005, 1, 1),
                    UserRole = "User"
                },
                new User
                {
                    UserID = 2,
                    UserName = "UserName2",
                    UserPassword = "435dfgrfgt",
                    UserBirthday = new DateTime(1996, 8, 10),
                    UserRole = "User"
                },
                new User
                {
                    UserID = 3,
                    UserName = "UserName3",
                    UserPassword = "48efge65",
                    UserBirthday = new DateTime(1987, 2, 6),
                    UserRole = "User"
                }
                );
            #endregion           

            #region CarSeed
            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    CarID = 11,
                    CarModel = "Tesla",
                    Desc = "Electic",
                    Img = "/img/Tesla.png",
                    Price = 23000,
                    UserID = 1
                },
                new Car
                {
                    CarID = 12,
                    CarModel = "Citroen C4 II",
                    Desc = "Fuel",
                    Img = "/img/Citroen.png",
                    Price = 6800,
                    UserID = 2
                },
                new Car
                {
                    CarID = 13,
                    CarModel = "Toyota Yaris",
                    Desc = "Fuel",
                    Img = "/img/Yaris.jpg",
                    Price = 5400,
                    UserID = 2
                },
                new Car
                {
                    CarID = 14,
                    CarModel = "BMW I3",
                    Desc = "Electic",
                    Img = "/img/BMW.png",
                    Price = 16000,
                    UserID = 3
                },
                new Car
                {
                    CarID = 15,
                    CarModel = "Wolkswagen Polo",
                    Desc = "Fuel",
                    Img = "/img/Polo.jpg",
                    Price = 9800,
                    UserID = 1
                }
                );
            #endregion

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .EnableSensitiveDataLogging()
                .UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=CarsShopDB;Trusted_Connection=True;");
        }
    }
    
}
