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
        public async Task Send(SignalRMessage message, User user)
        {
            
            await Clients.All.SendAsync("Receive", $"message: {message.MessageText}. From user: {user.Name}");
            await Console.Out.WriteLineAsync($"message: {message.MessageText}. From user: {user.Name}");
        }

        public async Task SendToUser(SignalRMessage message, User user)
        {
            var client = Clients.Client(user.Name);
            await client.SendAsync($"message: {message.MessageText}. From user: {user.Name}");
        }
        

    }
}
