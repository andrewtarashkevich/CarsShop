using CarsShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShop.BLL.DTO
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public string UserPassword { get; set; }
        public DateTime UserBirthday { get; set; }
        public int UserAge
        {
            get
            {
                int age;
                age = DateTime.Today.Year - UserBirthday.Year;
                if (UserBirthday.Date > DateTime.Today.AddYears(-age)) age--;
                return age;
            }
        }        
    }
}
