using System.ComponentModel.DataAnnotations;
using CarsShop.BLL.DTO;

namespace CarsShop.Models
{
    public class CarViewModel
    {
        public int CarID { get; set; }
        public string CarModel { get; set; }
        public string Desc { get; set; }
        public string Img { get; set; }
        public int Price { get; set; }
        public int UserID { get; set; }
    }
}
