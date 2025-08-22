using FoodTime.DAL.Interfaces;
using FoodTime.DAL.Repositories;
using FoodTime.Domain.Entity;
using FoodTime.Domain.Enum;
using FoodTime.Domain.Response;
using FoodTime.Domain.ViewModels;
using FoodTime.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IBaseResponse<bool>> DeleteProduct(int id)
        {
            var baseResponse = new BaseResponse<bool>();

            try
            {
                var product = await _productRepository.Get(id);
                if (product == null)
                {
                    baseResponse.Description = "Product not found";
                    baseResponse.StatusCode = StatusCode.ProductNotFound;
                    return baseResponse;
                }
                await _productRepository.Delete(product);
                baseResponse.Data = true;
                baseResponse.Description = "Product deleted successfully";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteProdouct] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<Product>> GetProduct(int id)
        {
            var baseResponse = new BaseResponse<Product>();

            try
            {
                var product = await _productRepository.Get(id);
                if (product == null)
                {                     
                    baseResponse.Description = "Product not found";
                    baseResponse.StatusCode = StatusCode.ProductNotFound;
                    return baseResponse;
                }
                baseResponse.Data = product;
                baseResponse.Description = "Product retrieved successfully";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<Product>()
                {
                    Description = $"[GetProduct] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Product>>> GetProducts()
        {
            var baseResponse = new BaseResponse<IEnumerable<Product>>();
            try
            {
                var products = await _productRepository.Select();
                
                if (products.Count == 0)
                {
                    baseResponse.Description = "Found 0 elements";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = products;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Product>>()
                {
                    Description = $"[GetProducts] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> BuyProduct(int id, int quantity)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var product = await _productRepository.Get(id);
                if (product == null)
                {
                    baseResponse.Description = "Ապրանքը չի գտնվել։";
                    baseResponse.StatusCode = StatusCode.ProductNotFound;
                    return baseResponse;
                }

                if (product.Stock < quantity) // Վավերացում (Validation)
                {
                    baseResponse.Description = $"Բավարար քանակ չկա։ Առկա է միայն {product.Stock} հատ։";
                    baseResponse.StatusCode = StatusCode.ProductNotFound;
                    return baseResponse;
                }

                product.Stock -= quantity; // Նվազեցնել առկա քանակը
                await _productRepository.Update(product); // Թարմացնել տվյալների բազայում

                baseResponse.Data = true;
                baseResponse.Description = "Գնումը հաջողությամբ կատարվեց։";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[BuyProduct] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Product>> CreateProduct(Product product)
        {
            var baseResponse = new BaseResponse<Product>();

            try
            {
                // Բիզնես տրամաբանության ստուգումը մնում է այստեղ
                var existingProduct = await _productRepository.GetByName(product.Name);
                if (existingProduct != null)
                {
                    baseResponse.Description = "Նման անունով ապրանք արդեն գոյություն ունի։";
                    baseResponse.StatusCode = StatusCode.ProductAlreadyExists;
                    return baseResponse;
                }



                await _productRepository.Create(product);

                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Description = "Ապրանքը հաջողությամբ ստեղծվեց։";
                baseResponse.Data = product;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Product>()
                {
                    Description = $"[CreateProduct] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }   
}
