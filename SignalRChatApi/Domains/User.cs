using SignalRChatApi.Domains.Common;

namespace SignalRChatApi.Domains;

public class User : BaseDomain
{ 
    public string Username { get; set; }
    public string? FullName { get; set; }
    public string? Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Avatar { get; set; }
    public string? Status { get; set; }
}