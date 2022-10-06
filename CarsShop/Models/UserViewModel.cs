using System.ComponentModel.DataAnnotations;

namespace CarsShop.Models
{
    public class UserViewModel
    {        
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public string Password { get; set; }                
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
