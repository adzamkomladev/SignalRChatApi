namespace SignalRChatApi.Data.Dtos.Users;

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? FullName { get; set; }
    public string? Avatar { get; set; }
}