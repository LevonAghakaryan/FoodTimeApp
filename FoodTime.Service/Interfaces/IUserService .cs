using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTime.Domain.Response;
using FoodTime.Domain.ViewModels;


namespace FoodTime.Service.Interfaces
{
    public interface IUserService
    {
        Task<IBaseResponse<bool>> Register(RegisterViewModel model);
        Task<IBaseResponse<bool>> Login(LoginViewModel model);
    }
}
