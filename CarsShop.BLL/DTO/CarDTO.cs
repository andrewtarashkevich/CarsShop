using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace CarsShop.BLL.DTO
{
    public class CarDTO
    {
        public int CarID { get; set; }
        public string CarModel { get; set; }
        public string Desc { get; set; }
        public string Img { get; set; }
        public int Price { get; set; }
        public int UserID { get; set; }
    }
}
