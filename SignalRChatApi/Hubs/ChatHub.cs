using Microsoft.AspNetCore.SignalR;

namespace SignalRChatApi.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        if (user == "komla")
        { 
            await Clients.All.SendAsync("ReceiveMessage", "This is an admin message: " + message);
            return;
        }

        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}