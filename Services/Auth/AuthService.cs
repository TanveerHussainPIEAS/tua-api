using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TUAApi.DBContext;
using TUAApi.DTO;
using TUAApi.Repository.Auth;

namespace TUAApi.Services.Auth
{
    public class AuthService : IAuthService
    {
        private IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        public AuthService(IAuthRepository authRepository, IMapper mapper)
        {
            _authRepository = authRepository;
            _mapper = mapper;
        }
        public async Task<AuthenticatedUserDto> LoginUser(LoginModelDto loginModelDto)
        {
            var user = await _authRepository.LoginUser(loginModelDto);
            var token = "";
            var dto= new AuthenticatedUserDto();

            if (user != null)
            {                
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:7134",
                    audience: "https://localhost:4200",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                token = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                dto = _mapper.Map<AuthenticatedUserDto>(user);
                dto.Token = token;
            }
             
            
            return dto;
        }

        public async Task<AuthenticatedUserDto> RegisterUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.CreatedDate= DateTime.Now;
            user.ModifiedDate= DateTime.Now;
            var loginModel = await _authRepository.RegisterUser(user);
            return await LoginUser(loginModel);
        }
    }
}
