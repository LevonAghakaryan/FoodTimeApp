using FoodTime.Domain.Entity;
using FoodTime.Domain.Response;
using FoodTime.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Service.Interfaces
{
    public interface IProductService
    {

        Task<IBaseResponse<IEnumerable<Product>>> GetProducts();

        Task<IBaseResponse<Product?>> GetProduct(int id);
        
        Task<IBaseResponse<bool>> DeleteProduct(int id);

        Task<IBaseResponse<Product>> CreateProduct(Product product);

        Task<IBaseResponse<bool>> BuyProduct(int id, int quantity);


    }
}
