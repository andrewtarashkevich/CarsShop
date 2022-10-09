using CarsShop.DAL.EF;
using CarsShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShop.DAL.Repositories
{
    public class CarRepository:IRepository<Car>
    {
        private UserContext db;
        public CarRepository(UserContext db)
        {
            this.db = db;
        }

        public void Create(Car car)
        {
            db.Cars.Add(car);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Car car = db.Cars.Find(id);
            if (car != null)
                db.Cars.Remove(car);
            db.SaveChanges();
        }

        public Car Get(int id)
        {
            return db.Cars.Find(id);
        }        

        public IEnumerable<Car> GetAll()
        {
            return db.Cars;
        }

        public void Update(Car car)
        {
            db.Entry(car).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        public void Save()
        {
            db.SaveChanges();
        }        
    }
}
