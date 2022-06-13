namespace SignalRChatApi.Repositories;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }

    Task Complete();
}