using Microsoft.EntityFrameworkCore;
using SignalRChatApi.Data.Dtos.Common;
using SignalRChatApi.Data.Dtos.Users;
using SignalRChatApi.Database;
using SignalRChatApi.Domains;

namespace SignalRChatApi.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ChatApiDbContext context) : base(context)
    {
    }

    public async Task<User?> FindByUsername(string username) => await Find(u => u.Username == username).FirstOrDefaultAsync();
    public async Task<IEnumerable<UserDto>> GetAllUsers(GetAllUsersFilterDto filter)
    {
        var query = GetAllUsersFilteredQueryable(filter);

        return await query
            .Skip((filter.Page - 1) * filter.Size)
            .Take(filter.Size)
            .Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username,
                Phone = u.Phone,
                Avatar = u.Avatar,
                FullName = u.FullName,
                Email = u.Email,
            })
            .ToListAsync();
    }

    public async Task<Meta> GetAllUsersMeta(GetAllUsersFilterDto filter)
    {
        var query = GetAllUsersFilteredQueryable(filter);

        var totalUsers = await query.CountAsync();
        var usersCount = query.Skip((filter.Page - 1) * filter.Size)
            .Take(filter.Size)
            .Count();
        var totalPages = (int)Math.Ceiling((double)totalUsers / filter.Size);

        return new Meta
        {
            Total = totalUsers,
            Current = filter.Page,
            Size = usersCount,
            Pages = totalPages,
            Next = filter.Page + 1 > totalPages ? null : filter.Page + 1,
            Previous = filter.Page - 1 < 1 ? null : filter.Page - 1,
        };
    }

    private IQueryable<User> GetAllUsersFilteredQueryable(GetAllUsersFilterDto filter)
    {
        var query = Context.Set<User>().AsQueryable();

        if (filter.Search is not null) query = query.Where(u => u.Username.Contains(filter.Search) || filter.Search.Contains(u.Phone ?? "") || filter.Search.Contains(u.FullName ?? "") || filter.Search.Contains(u.Email ?? ""));

        return query;
    }
}