using TUAApi.DTO;

namespace TUAApi.Services.Auth
{
    public interface IAuthService
    {
        Task<AuthenticatedUserDto> LoginUser(LoginModelDto loginModelDto);
        Task<AuthenticatedUserDto> RegisterUser(UserDto userDto);
    }
}
