using SignalRChatApi.Domains.Common;

namespace SignalRChatApi.Domains;

public class UserSetting : BaseDomain
{
    public int UserId { get; set; }
    public bool RememberMe { get; set; }
    public int RememberDuration { get; set; }
    public bool IsVisible { get; set; }
    public User User { get; set; }
}