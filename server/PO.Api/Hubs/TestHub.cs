using Microsoft.AspNetCore.SignalR;

namespace PO.Api.Hubs
{
    public class TestHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
