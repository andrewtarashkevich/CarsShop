using CarsShop.BLL.DTO;
using CarsShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShop.BLL.Services
{
    public interface ICarService
    {
        //получает объект для сохранения с уровня представления и создает по нему объект Car и сохраняет его в базу данных.
        void CreateCar(CarDTO carDto);

        //передает отдельный car на уровень представления.
        CarDTO GetCar(int? id);

        //получает все cars и с помощью автомаппера преобразует их в CarDTO и передает на уровень представления.
        IEnumerable<CarDTO> GetCars();
        
        void Delete(int? id);
    }
}
