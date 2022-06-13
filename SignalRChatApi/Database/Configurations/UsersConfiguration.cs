using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignalRChatApi.Domains;

namespace SignalRChatApi.Database.Configurations;

public class UsersConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Username).IsRequired().HasMaxLength(100);
        builder.HasIndex(e => e.Username).IsUnique();

        builder.Property(e => e.Phone).HasMaxLength(20);

        builder.Property(e => e.Email).HasMaxLength(100);

        builder.Property(e => e.Gender).HasMaxLength(50);

        builder.Property(e => e.FullName).HasMaxLength(200);

        Seed(builder);
    }

    private static void Seed(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User
            {
                Id = 1,
                Username = "Top Shatta",
            }
        );
    }
}