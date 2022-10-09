using AutoMapper;
using CarsShop.BLL.DTO;
using CarsShop.DAL.Entities;
using CarsShop.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShop.BLL.Services
{
    public class CarService : ICarService
    {
        CarRepository CarDatabase { get; set; }
        public CarService(CarRepository carDatabase)
        {
            CarDatabase = carDatabase;
        }

        public void Delete(int? id)
        {            
            var car = CarDatabase.Get(id.Value);           
            CarDatabase.Delete(car.CarID);
        }

        public IEnumerable<CarDTO> GetCars()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Car, CarDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Car>, List<CarDTO>>(CarDatabase.GetAll());
        }

        public CarDTO GetCar(int? id)
        {            
            var car = CarDatabase.Get(id.Value);
            if (car == null)
                throw new ValidationException("Car не найден", "");

            return new CarDTO { CarID = car.CarID, CarModel = car.CarModel, Desc = car.Desc, Img = car.Img, Price = car.Price, UserID = car.UserID};
        }

        public void CreateCar(CarDTO carDto)
        {            
            Car car = new Car
            {
                CarID = carDto.CarID,
                CarModel = carDto.CarModel,
                Desc = carDto.Desc,
                Img = carDto.Img,
                Price = carDto.Price,
                UserID = carDto.UserID
            };

            CarDatabase.Create(car);
            CarDatabase.Save();
        }
        
    }
}
