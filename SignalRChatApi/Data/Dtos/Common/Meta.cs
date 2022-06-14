namespace SignalRChatApi.Data.Dtos.Common;

public class Meta
{
    public int? Previous { get; set; }
    public int? Next { get; set; }
    public int Current { get; set; }
    public int Pages { get; set; }
    public int Size { get; set; }
    public int Total { get; set; }

}