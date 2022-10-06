﻿using CarsShop.BLL.DTO;
using CarsShop.DAL.Entities;
using CarsShop.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace CarsShop.BLL.Services
{
    public class UserService : IUserService
    {
        UserRepository UserDatabase { get; set; }
        public UserService(UserRepository userDatabase)
        {
            UserDatabase = userDatabase;
        }

        public void Delete(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id", "");

            var user = UserDatabase.Get(id.Value);
            if (user == null)
                throw new ValidationException("User не найден", "");

            UserDatabase.Delete(user.UserID);
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(UserDatabase.GetAll());
        }

        public UserDTO GetUser(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id", "");

            var user = UserDatabase.Get(id.Value);
            if (user == null)
                throw new ValidationException("User не найден", "");

            return new UserDTO { UserName = user.UserName, UserID = user.UserID, UserBirthday = user.UserBirthday, UserPassword = user.UserRole, UserRole = user.UserRole };
        }

        public void CreateUser(UserDTO userDto)
        {
            // валидация
            if (UserDatabase.Get(userDto.UserID) != null)
                throw new ValidationException("Валидация не пройдена", "");

            User user = new User
            {
                UserName = userDto.UserName,
                UserID = userDto.UserID,
                UserBirthday = userDto.UserBirthday,
                UserPassword = userDto.UserPassword,
                UserRole = userDto.UserRole
            };

            UserDatabase.Create(user);
            UserDatabase.Save();
        }

        //public ClaimsIdentity Authenticate(UserDTO userDto)
        //{
        //    ClaimsIdentity claim = null;
        //    // находим пользователя
        //    User user = UserDatabase.Get(userDto.UserID);
        //    // авторизуем его и возвращаем объект ClaimsIdentity
        //    if (user != null)
        //        claim = UserDatabase.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
        //    return claim;
        //}
    }
}