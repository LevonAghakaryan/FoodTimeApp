using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FoodTime.Domain.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Մուտքագրեք օգտանուն")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Մուտքագրեք անուն")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Մուտքագրեք էլ. հասցե")]
        [EmailAddress(ErrorMessage = "Սխալ էլ. հասցե")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Մուտքագրեք գաղտնաբառ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Հաստատեք գաղտնաբառը")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Գաղտնաբառերը չեն համընկնում")]
        public string ConfirmPassword { get; set; }

     }
}
