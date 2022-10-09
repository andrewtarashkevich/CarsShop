using AutoMapper;
using CarsShop.BLL.DTO;
using CarsShop.BLL.Services;
using CarsShop.DAL.Entities;
using CarsShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarsShop.Controllers
{
    public class CarsController : Controller
    {
        public ICarService carService;
        public CarsController(ICarService serv)
        {
            carService = serv;
        }
        public IActionResult Index()
        {
            IEnumerable<CarDTO> carDtos = carService.GetCars();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CarDTO, CarViewModel>()).CreateMapper();
            var cars = mapper.Map<IEnumerable<CarDTO>, List<CarViewModel>>(carDtos);
            return View(cars);     
        }
        public IActionResult GetCar(int? id)
        {
            try
            {
                CarDTO car = carService.GetCar(id);
                return View(car);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }        

        [HttpPost]
        public IActionResult CreateCar(CarViewModel car)
        {
            try
            {
                var carDto = new CarDTO { CarID = car.CarID, CarModel = car.CarModel, Desc = car.Desc, Img = car.Img, Price = car.Price, UserID = car.UserID};
                carService.CreateCar(carDto);
                return Content("<h2>Car added</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(car);
        }
        public IActionResult Delete(int? id)
        {
            try
            {
                CarDTO car = carService.GetCar(id);
                carService.Delete(car.CarID);
                return Content("<h2>Car deleted</h2>");
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }        
    }
}
