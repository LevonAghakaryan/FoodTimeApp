using FoodTime.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.DAL.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<bool> Update(Product entity);
        Task<Product> GetByName(string name);
    }
}
