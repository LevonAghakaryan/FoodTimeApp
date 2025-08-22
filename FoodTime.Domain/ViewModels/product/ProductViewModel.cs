using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace FoodTime.Domain.ViewModels
{
    public class ProductViewModel
    {
        [Required(ErrorMessage = "Ապրանքի անունը պարտադիր է։")]
        [StringLength(100, ErrorMessage = "Անվանման առավելագույն երկարությունը 100 նիշ է։")]
        public string Name { get; set; }

        [Display(Name = "Նկարագրություն")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Գինը պարտադիր է։")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Գինը պետք է լինի 0-ից մեծ։")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Քանակը պարտադիր է։")]
        [Range(1, int.MaxValue, ErrorMessage = "Քանակը պետք է լինի 1-ից մեծ։")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Նկարի հղումը պարտադիր է։")]
        public string ImageUrl { get; set; }
    }
}