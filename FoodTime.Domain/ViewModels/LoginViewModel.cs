using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FoodTime.Domain.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Մուտքագրեք օգտանուն")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Մուտքագրեք գաղտնաբառ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
