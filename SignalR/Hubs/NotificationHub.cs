using Microsoft.AspNetCore.SignalR;
using Signal.Interfaces;

namespace Signal.Hubs;

public class NotificationHub : Hub<INotificationClient>
{
    public Task SendMessage(string msg)
    {
        return Clients.All.Send(msg);
    }

    public async IAsyncEnumerable<int> SendStream(CancellationToken token)
    {
        var i = 0;
        while (!token.IsCancellationRequested)
        {
            yield return i++;
            await Task.Delay(1000, token);
        }
    }

    public override Task OnConnectedAsync()
    {
        Clients.Caller.Send(Context.ConnectionId);

        return base.OnConnectedAsync();
    }
}