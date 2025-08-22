using FoodTime.Domain.Entity;
using FoodTime.Domain.Enum;
using FoodTime.Domain.ViewModels;
using FoodTime.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace FoodTime.Controllers
{
    public class ProductController : Controller
    {   

        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var response = await _productService.GetProducts();

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response);
            }
            return RedirectToAction("Error");

        }

        [HttpGet]
        public async Task<IActionResult> GetProduct(int id)
        {
            var response = await _productService.GetProduct(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }


        [HttpPost]
        public async Task<IActionResult> BuyProduct(int productId, int quantity)
        {
            var response = await _productService.BuyProduct(productId, quantity);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetProducts"); // Գնումից հետո վերադառնալ ցուցակ
            }
            else
            {
                // Ցուցադրել սխալի մասին հաղորդագրություն
                // Դուք կարող եք ստեղծել նոր Error.cshtml, որը կցուցադրի հաղորդագրությունը
                return RedirectToAction("Error", "Home", new { message = response.Description });
            }
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Փոխակերպել ViewModel-ը Domain մոդելի
                var product = new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    Stock = model.Stock,
                    ImageUrl = model.ImageUrl
                };

                // Փոխանցել մաքուր Domain մոդելը Service-ին
                var response = await _productService.CreateProduct(product);

                if (response.StatusCode == FoodTime.Domain.Enum.StatusCode.OK)
                {
                    // Եթե հաջող է, ուղղորդել դեպի GetProducts էջ
                    return RedirectToAction("GetProducts");
                }

                // Եթե սխալ կա, ցուցադրել այն View-ում
                ModelState.AddModelError("", response.Description);
            }

            // Եթե ModelState-ը վավեր չէ, վերադարձնել նույն View-ը սխալներով
            return View(model);
        }
    }
}
