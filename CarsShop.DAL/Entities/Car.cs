using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShop.DAL.Entities
{
    public class Car
    {
        public int CarID { get; set; }
        public string CarModel { get; set; }
        public string Desc { get; set; }
        public string Img { get; set; }
        public int Price { get; set; }       
        public int UserID { get; set; }
    }
}
