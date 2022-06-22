using Microsoft.EntityFrameworkCore;
using SignalRChatApi.Domains;
using SignalRChatApi.Domains.Common;

namespace SignalRChatApi.Database;

public class ChatApiDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<UserSetting> UserSettings => Set<UserSetting>();

    public ChatApiDbContext(DbContextOptions<ChatApiDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChatApiDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseDomain>())
        {
            entry.Entity.UpdatedAt = DateTime.Now;

            if (entry.State == EntityState.Added) entry.Entity.CreatedAt = DateTime.Now;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}