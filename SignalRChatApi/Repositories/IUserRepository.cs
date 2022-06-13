using SignalRChatApi.Domains;

namespace SignalRChatApi.Repositories;

public interface IUserRepository : IRepository<User>
{
    public Task<User?> FindByUsername(string username);
}