using Microsoft.AspNetCore.SignalR;
using SocketChat.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketChat.BLL.Logic
{
    public class ChatHub : Hub
    {
        public async Task Send(SignalRMessage message)
        {
            //await Clients.All.SendAsync($"message: {message.Message}. From user: {message.FromUser}");
            await Clients.All.SendAsync("Receive", $"message: {message.Message}. From user: {message.FromUser}");
            await Console.Out.WriteLineAsync($"message: {message.Message}. From user: {message.FromUser}");
        }

        public async Task SendToUser(SignalRMessage message)
        {
            var client = Clients.Client(message.ConnectionId);
            await client.SendAsync($"message: {message.Message}. From user: {message.FromUser}");
        }

    }
}
