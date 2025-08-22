// Controllers/CartController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Collections.Generic;
using FoodTime.Domain.Entity;
using FoodTime.Service.Interfaces;

public class CartController : Controller
{
    private readonly IProductService _productService;
    public CartController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> AddToCart(int productId, int quantity)
    {
        // Գտնել ապրանքը service-ի միջոցով
        var productResponse = await _productService.GetProduct(productId);
        if (productResponse.StatusCode != FoodTime.Domain.Enum.StatusCode.OK)
        {
            return RedirectToAction("Error", "Home", new { message = productResponse.Description });
        }
        var product = productResponse.Data;

        // Ստուգել քանակը
        if (product.Stock < quantity)
        {
            return RedirectToAction("Error", "Home", new { message = "Բավարար քանակ չկա։" });
        }

        // Ստանալ զամբյուղը session-ից
        var cartJson = HttpContext.Session.GetString("ShoppingCart");
        var cart = cartJson == null ? new List<Product>() : JsonSerializer.Deserialize<List<Product>>(cartJson);

        // Ավելացնել ապրանքը զամբյուղ
        var existingProduct = cart.FirstOrDefault(p => p.Id == productId);
        if (existingProduct != null)
        {
            existingProduct.Stock += quantity; // Քանակը մեծացնել
        }
        else
        {
            product.Stock = quantity; // Քանակը դարձնել գնվածի քանակը
            cart.Add(product);
        }

        // Պահպանել զամբյուղը session-ում
        HttpContext.Session.SetString("ShoppingCart", JsonSerializer.Serialize(cart));

        return RedirectToAction("GetProducts", "Product");
    }

    public IActionResult Index()
    {
        var cartJson = HttpContext.Session.GetString("ShoppingCart");
        var cart = cartJson == null ? new List<Product>() : JsonSerializer.Deserialize<List<Product>>(cartJson);

        return View(cart);
    }
}