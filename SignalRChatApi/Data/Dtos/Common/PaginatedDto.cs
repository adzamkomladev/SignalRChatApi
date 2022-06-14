namespace SignalRChatApi.Data.Dtos.Common;

public class Paginated<T> where T: class
{
    public IEnumerable<T> Data { get; set; }
    public Meta Meta { get; set; }
}