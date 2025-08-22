using FoodTime.DAL.Interfaces;
using FoodTime.Domain.Entity;
using FoodTime.Domain.Enum;
using FoodTime.Domain.Response;
using FoodTime.Domain.ViewModels;
using FoodTime.Service.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IBaseResponse<bool>> Register(RegisterViewModel model)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var user = await _userRepository.GetByUserName(model.UserName);
                if (user != null)
                {
                    baseResponse.Description = "Օգտատերն արդեն գրանցված է";
                    baseResponse.StatusCode = StatusCode.InternalServerError;
                    return baseResponse;
                }

                // Գաղտնաբառի հեշավորում
                var passwordHash = HashPassword(model.Password);

                user = new User()
                {
                    UserName = model.UserName,
                    Name = model.Name,
                    Email = model.Email,
                    PasswordHash = passwordHash
                };

                await _userRepository.Create(user);

                baseResponse.Data = true;
                baseResponse.Description = "Գրանցումը հաջողությամբ ավարտվեց";
                baseResponse.StatusCode = StatusCode.OK;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[Register] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<bool>> Login(LoginViewModel model)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var user = await _userRepository.GetByUserName(model.UserName);
                if (user == null)
                {
                    baseResponse.Description = "Օգտատերը չի գտնվել կամ գաղտնաբառը սխալ է";
                    baseResponse.StatusCode = StatusCode.Unauthorized;
                    return baseResponse;
                }

                if (!VerifyPasswordHash(model.Password, user.PasswordHash))
                {
                    baseResponse.Description = "Օգտատերը չի գտնվել կամ գաղտնաբառը սխալ է";
                    baseResponse.StatusCode = StatusCode.Unauthorized;
                    return baseResponse;
                }

                baseResponse.Data = true;
                baseResponse.Description = "Մուտքը հաջողությամբ կատարվեց";
                baseResponse.StatusCode = StatusCode.OK;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[Login] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            return baseResponse;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        private bool VerifyPasswordHash(string password, string storedHash)
        {
            var newHash = HashPassword(password);
            return newHash.Equals(storedHash);
        }
    }
}