using SignalRChatApi.Data.Dtos.Common;
using SignalRChatApi.Data.Dtos.Users;
using SignalRChatApi.Domains;

namespace SignalRChatApi.Repositories;

public interface IUserRepository : IRepository<User>
{
    public Task<User?> FindByUsername(string username);
    public Task<IEnumerable<UserDto>> GetAllUsers(GetAllUsersFilterDto filter);
    public Task<Meta> GetAllUsersMeta(GetAllUsersFilterDto filter);
}