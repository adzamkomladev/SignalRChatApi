namespace SignalRChatApi.Data.Dtos.Users;

public class GetAllUsersFilterDto
{
    public string? Search { get; set; }
    public bool? IsOnline { get; set; }
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
}