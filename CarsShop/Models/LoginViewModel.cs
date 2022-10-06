using System.ComponentModel.DataAnnotations;

namespace CarsShop.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
    }
}
