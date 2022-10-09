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
        public IActionResult GetUser(int? id)
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
                var userDto = new UserDTO { UserName = user.UserName, UserID = user.UserID, UserBirthday = user.UserBirthday, UserPassword = user.Password, UserRole = user.UserRole};
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
        
    }
}
