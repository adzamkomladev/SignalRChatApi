using SignalRChatApi.Database;

namespace SignalRChatApi.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ChatApiDbContext _context;

    private IUserRepository _users;

    public UnitOfWork(ChatApiDbContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public IUserRepository Users => _users ??= new UserRepository(_context);

    public async Task Complete()
    {
        await _context.SaveChangesAsync();
    }
}