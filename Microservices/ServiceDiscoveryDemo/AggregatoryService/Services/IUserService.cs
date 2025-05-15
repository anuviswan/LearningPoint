
namespace AggregatoryService.Services;

public interface IUserService
{
    Task<UserService.UserDto?> GetUserByIdAsync(string userId);
}