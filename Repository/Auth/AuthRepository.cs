using Microsoft.EntityFrameworkCore;
using TUAApi.DBContext;
using TUAApi.DTO;

namespace TUAApi.Repository.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private TuaDbContext _dBContext;
        public AuthRepository(TuaDbContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<User> LoginUser(LoginModelDto loginModelDto)
        {
            var user = await _dBContext.Users.Where(u => u.Deleted == false && u.Email == loginModelDto.Email && u.Password==loginModelDto.Password).FirstOrDefaultAsync();
            return user;
        }

        public async Task<LoginModelDto> RegisterUser(User user)
        {
            await _dBContext.Users.AddAsync(user);
            await _dBContext.SaveChangesAsync();
            var dto = new LoginModelDto
            {
                Email = user.Email,
                Password = user.Password,
            };
            return dto;
        }
    }
}
