using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignalRChatApi.Domains;

namespace SignalRChatApi.Database.Configurations;

public class UserSettingsConfiguration
{
    public void Configure(EntityTypeBuilder<UserSetting> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasOne(us => us.User)
            .WithOne(u => u.Settings)
            .HasForeignKey<UserSetting>(us => us.UserId);

        Seed(builder);
    }

    private static void Seed(EntityTypeBuilder<UserSetting> builder)
    {
        builder.HasData(
            new UserSetting
            {
                Id = 1,
                Username = "Top Shatta",
            }
        );
    }
}