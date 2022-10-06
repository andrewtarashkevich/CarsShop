using AutoMapper;
using CarsShop.BLL.DTO;
using CarsShop.BLL.Services;
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
        public ActionResult GetCar(int? id)
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
                var carDto = new CarDTO { CarID = car.CarID, CarModel = car.CarModel, Desc = car.Desc, Img = car.Img, Price = car.Price, UserID = car.UserID };
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
        //Старые методы для одного слоя
        //public static List<CarViewModel> StaticCars { get; } = new List<CarViewModel>
        //{
        //    new()
        //    {
        //       CarID = 01,
        //       CarModel = "Tesla",
        //       Desc = "Electic",
        //       Img = "/img/Tesla.png",
        //       Price = 23000,
        //       ID = 0
        //    },
        //    new()
        //    {
        //       CarID = 11,
        //       CarModel = "Citroen C4 II",
        //       Desc = "Fuel",
        //       Img = "/img/Citroen.png",
        //       Price = 6800,
        //       ID = 1
        //    },
        //    new()
        //    {
        //       CarID = 11,
        //       CarModel = "BMW I3",
        //       Desc = "Electic",
        //       Img = "/img/BMW.png",
        //       Price = 16000,
        //       ID = 1
        //    },
        //    new()
        //    {
        //       CarID = 11,
        //       CarModel = "Toyota Yaris",
        //       Desc = "Fuel",
        //       Img = "/img/Yaris.jpg",
        //       Price = 5400,
        //       ID = 1
        //    },
        //    new()
        //    {
        //       CarID = 11,
        //       CarModel = "Wolkswagen Polo",
        //       Desc = "Fuel",
        //       Img = "/img/Polo.jpg",
        //       Price = 9800,
        //       ID = 1
        //    },
        //};

        //public IActionResult Index()
        //{
        //    var carsViewModel = new CarsViewModel();
        //    carsViewModel.Cars = StaticCars;
        //    return View(carsViewModel);            
        //}
        //public IActionResult CreateCar(CreateCarViewModel createCarViewModel)
        //{
        //    StaticCars.Add(new CarViewModel
        //    {
        //        CarID = createCarViewModel.CarID,
        //        CarModel = createCarViewModel.CarModel,
        //        Desc = createCarViewModel.Desc,
        //        Img = createCarViewModel.Img,
        //        Price = createCarViewModel.Price,
        //        ID = createCarViewModel.ID
        //    });
        //    return RedirectToAction("Index");
        //}
    }
}
