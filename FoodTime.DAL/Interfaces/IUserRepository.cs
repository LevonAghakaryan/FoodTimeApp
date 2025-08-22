using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTime.Domain.Entity;
using System.Threading.Tasks;


namespace FoodTime.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> Create(User entity);
        Task<User?> GetByUserName(string userName);
    }
}