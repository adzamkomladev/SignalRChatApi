using SignalRChatApi.Data.Dtos.Users;
using SignalRChatApi.Domains;

namespace SignalRChatApi.Services;

public interface IUserService
{
    public Task<User?> CreateAsync(CreateUserDto userDto);
    public Task<FilteredUsersDto> GetAllUsersFilteredAndPaginated(GetAllUsersFilterDto filterDto);
}