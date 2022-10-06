using Microsoft.AspNetCore.Mvc;
using CarsShop.Models;
using CarsShop.BLL.Services;
using AutoMapper;
using CarsShop.BLL.DTO;
using CarsShop.DAL.Entities;

namespace CarsShop.Controllers
{
    public class UsersController : Controller
    {
        public IUserService userService;
        public UsersController(IUserService serv)
        {
            userService = serv;
        }       
        public IActionResult Index()
        {
            IEnumerable<UserDTO> userDtos = userService.GetUsers();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var users = mapper.Map<IEnumerable<UserDTO>, List<UserViewModel>>(userDtos);
            return View(users);

            //Старый вариант для одного слоя //var usersViewModel = new UsersViewModel();
            //usersViewModel.Users = StaticUsers;
            //return View(usersViewModel);            
        }       
        public ActionResult GetUser(int? id)
        {
            try
            {
                UserDTO user = userService.GetUser(id);
                return View(user);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateUser(UserViewModel user)
        {
            try
            {
                var userDto = new UserDTO { UserName = user.UserName, UserID = user.UserID, UserBirthday = user.UserBirthday, UserPassword = user.UserRole, UserRole = user.UserRole };
                userService.CreateUser(userDto);
                return Content("<h2>User added</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(user);
        }
        public IActionResult Delete(int? id)
        {
            try
            {
                UserDTO user = userService.GetUser(id);
                userService.Delete(user.UserID);
                return Content("<h2>User deleted</h2>");
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        //Старые методы для одного слоя
        //public static List<UserViewModel> StaticUsers { get; } = new List<UserViewModel>
        //{
        //    new()
        //    {
        //       ID = 0,
        //       UserRole = "Admin",
        //       UserName = "Admin",
        //       UserBirthday = new DateTime(1996, 6, 2)
        //    },
        //    new()
        //    {
        //       ID = 1,
        //       UserRole = "User",
        //       UserName = "User1",
        //       UserBirthday = new DateTime(1991, 8, 11)
        //    },
        //    new()
        //    {
        //       ID = 2,
        //       UserRole = "User",
        //       UserName = "USer2",
        //       UserBirthday = new DateTime(1992, 2, 22)
        //    },
        //    new()
        //    {
        //       ID = 3,
        //       UserRole = "User",
        //       UserName = "User3",
        //       UserBirthday = new DateTime(1994, 5, 12)
        //    },
        //};
        //public IActionResult CreateUser(CreateUserViewModel createUserViewModel)
        //{
        //    StaticUsers.Add(new UserViewModel
        //    {
        //        ID = StaticUsers.Count,
        //        UserRole = createUserViewModel.UserRole,
        //        UserName = createUserViewModel.UserName,
        //        UserBirthday = createUserViewModel.UserBirthday

        //    });
        //    return RedirectToAction("Index");
        //}
    }
}
