using TUAApi.DTO.User;
namespace TUAApi.DTO
{
    public class AuthenticatedUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public UserPermissionDto Permission { get; set; }
    }
}
