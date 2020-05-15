using ManualAuthenticationSample.Common;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualAuthenticationSample.Hubs
{
    public class ChatHub : Hub
    {
        //Client Side Package for SignalR
        //@microsoft/signalr

        public override Task OnConnectedAsync()
        {
            var connectionId = this.Context.ConnectionId;
            SignalrUsers.Users.Add(connectionId, "");
            return base.OnConnectedAsync();
        }

        public async Task Send(string sender, string message)
        {
            checkExistsInUsers(sender, this.Context.ConnectionId);
            await Clients.All.SendAsync("broadcastMessage", sender, message);
        }

        private void checkExistsInUsers(string sender, string connectionId)
        {
            SignalrUsers.Users[this.Context.ConnectionId] = sender;
        }

        public async Task SendForUser(string sender, string reciveUser, string message)
        {
            checkExistsInUsers(sender, this.Context.ConnectionId);
            var connectionId = SignalrUsers.Users.SingleOrDefault(q => q.Value == reciveUser).Key;

            await Clients.Client(connectionId).SendAsync("specificMessage", sender, message);
        }
    }
}
