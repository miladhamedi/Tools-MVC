using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ChatSample.Hubs
{
        public class ChatHub : Hub
        {
            //Client Side Package for SignalR
            //@microsoft/signalr

            public async Task Send(string sender, string message)
            {
                // Call the broadcastMessage method to update clients.
                await Clients.All.SendAsync("broadcastMessage", sender, message);
            }
        }
}