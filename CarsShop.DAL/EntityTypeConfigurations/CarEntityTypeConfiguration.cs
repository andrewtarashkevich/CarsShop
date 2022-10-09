using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsShop.DAL.Entities;

namespace CarsShop.DAL.EntityTypeConfigurations
{
    public class CarEntityTypeConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(car => car.CarID);
            //builder.HasOne<User>().WithMany().HasForeignKey(car => car.UserID);
            builder.HasOne(c => c.User).WithMany(c => c.Cars).HasForeignKey(car => car.UserID);
        }
    }
}
