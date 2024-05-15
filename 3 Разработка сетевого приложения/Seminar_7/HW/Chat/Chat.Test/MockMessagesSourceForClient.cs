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
    public class MockMessagesSourceForClient : IMessageSource
    {
        private ChatClient _chatClient;
        private UdpClient _udpClient;
        private Queue<ChatMessage> _messages1 = new Queue<ChatMessage>();
        private IPEndPoint _udpServerEndPoint;

        public ChatClient ChatClient
        {
            get => _chatClient;
            set => _chatClient = value;
        }

        public void InitializeClient(ChatClient chatClient)
        {
            ChatClient = chatClient;
        }

        public MockMessagesSourceForClient(int port, string address = "127.0.0.1", int portServer = 12345)
        {
            _udpClient = new UdpClient(port);
            _udpServerEndPoint = new IPEndPoint(IPAddress.Parse(address), portServer);
            
            _messages1.Enqueue(new ChatMessage()
            { Command = Command.Message, FromName = "Alex", ToName = "Ivan", Text = "Hi" });
            
        }

        public IPEndPoint CreateNewIPEndPoint()
        {
            return new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
        }

        public IPEndPoint GetServerIPEndPoint()
        {
            return new IPEndPoint(_udpServerEndPoint.Address, _udpServerEndPoint.Port);
        }

        public ChatMessage Receive(ref IPEndPoint ipEndPoint)
        {
            return _messages1.Dequeue();
        }

        public void SendMessage(ChatMessage chatMessage, IPEndPoint ipEndPoint)
        {
            ipEndPoint = _udpServerEndPoint;
            if (_messages1.Count > 0)
            {
                var message = _messages1.Dequeue();
                byte[] data = Encoding.UTF8.GetBytes(message.ToJson());
                _udpClient.Send(data, data.Length, ipEndPoint);
            }
            else
            {
                ChatClient.Stop();
            }
        }
    }
}