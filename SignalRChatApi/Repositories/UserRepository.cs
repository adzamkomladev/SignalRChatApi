using Microsoft.EntityFrameworkCore;
using SignalRChatApi.Database;
using SignalRChatApi.Domains;

namespace SignalRChatApi.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ChatApiDbContext context) : base(context)
    {
    }

    public async Task<User?> FindByUsername(string username) => await Find(u => u.Username == username).FirstOrDefaultAsync();
}