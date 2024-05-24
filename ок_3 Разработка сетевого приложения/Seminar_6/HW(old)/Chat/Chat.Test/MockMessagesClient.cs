using ChatApp;
using ChatNetwork;
using CommonChat.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Test
{
    public class MockMessagesClient : IMessageSource
    {
        private Queue<ChatMessage> _messages = new();

        private ChatClient _chatClient;
        private UdpClient _udpClient = new UdpClient(0);
        private IPEndPoint _udpServerEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 55555);

        public ChatClient ChatClient
        {
            get => _chatClient;
            set => _chatClient = value;
        }


        public void InitializeClient(ChatClient chatClient)
        {
            ChatClient = chatClient;
        }



        public MockMessagesClient()
        {
            _messages.Enqueue(new ChatMessage() { Command = Command.Register, FromName = "Alex" });
            _messages.Enqueue(new ChatMessage() { Command = Command.Register, FromName = "Ivan" });
            _messages.Enqueue(new ChatMessage() { Command = Command.Message, FromName = "Alex", ToName = "Ivan", Text = "Hi" });
        }

        public IPEndPoint CreateNewIPEndPoint()
        {
            return new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
        }

        public ChatMessage ReceiveMessage(ref IPEndPoint ipEndPoint)
        {
            _udpServerEndPoint = ipEndPoint;

            if (_messages.Count == 0)
            {
                ChatClient.Stop();
                return null;
            }

            return _messages.Dequeue();
        }

        public void SendMessage(ChatMessage chatMessage, IPEndPoint ipEndPoint)
        {
            _udpServerEndPoint = ipEndPoint;
            if (_messages.Count > 0)
            {
                var message = _messages.Dequeue();
                byte[] data = Encoding.UTF8.GetBytes(message.ToJson());
                _udpClient.Send(data, data.Length, _udpServerEndPoint);
            }
            else
            {
                ChatClient.Stop();
            }
        }

        public IPEndPoint GetServerIPEndPoint()
        {
            return new IPEndPoint(_udpServerEndPoint.Address, _udpServerEndPoint.Port);
        }
    }
}