using CarsShop.BLL.DTO;
using CarsShop.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace CarsShop.BLL.Services
{
    public interface IUserService
    {
        //получает объект для сохранения с уровня представления и создает по нему объект User и сохраняет его в базу данных.
        void CreateUser(UserDTO userDto);
        //передает отдельного user на уровень представления.
        UserDTO GetUser(int? id);
        //получает одного user
        IEnumerable<UserDTO> GetUsers();
        //получает все users и с помощью автомаппера преобразует их в UserDTO и передает на уровень представления.
        void Delete(int? id);
        //ClaimsIdentity Authenticate(UserDTO userDto);        
    }
}
