using TUAApi.DBContext;
using TUAApi.DTO;

namespace TUAApi.Repository.Auth
{
    public interface IAuthRepository
    {
        Task<User> LoginUser(LoginModelDto loginModelDto);
        Task<LoginModelDto> RegisterUser(User userDto);
    }
}
