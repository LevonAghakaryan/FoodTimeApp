using FoodTime.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTime.Domain.Entity;
using Microsoft.EntityFrameworkCore;
namespace FoodTime.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {   
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Product entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Product entity)
        {
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Product?> Get(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> GetByName(string name)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<Product>> Select()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<bool> Update(Product entity)
        {
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
