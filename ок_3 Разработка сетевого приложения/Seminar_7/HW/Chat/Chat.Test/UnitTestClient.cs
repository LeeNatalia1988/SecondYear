using ChatApp;
using ChatDB;
using ChatNetwork;
using CommonChat.DTO;
using System.Net;

namespace Chat.Test
{
    public class TestForClient
    {
        [SetUp]
        public void Setup()
        {
            using (var context = new ChatContext())
            {
                context.Messages.RemoveRange(context.Messages);
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();
            }
        }

        [TearDown]
        public void Teardown()
        {
            using (var context = new ChatContext())
            {
                context.Messages.RemoveRange(context.Messages);
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();
            }
        }

        [Test]
        public async Task Test()
        {
            var mockForServer = new MockMessagesSourceForServer();
            var server = new ChatServer(mockForServer);
            mockForServer.InitializeServer(server);
            server.Work();

            await Task.Delay(2000);

            var mockForClient = new MockMessagesSourceForClient(12341);
            var client = new ChatClient("Alex", mockForClient);
            mockForClient.InitializeClient(client);
            //client.Start();
            client.SendMessage(new ChatMessage()
            { Command = Command.Message, FromName = "Alex", ToName = "Alex", Text = "Hi" }, new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345));

            using (var context = new ChatContext())
            {
                var alex = context.Users.FirstOrDefault(x => x.Name == "Alex");
                Assert.IsNotNull(alex);

                Assert.IsTrue(alex.FromMessages.Count == 1);
                
                var messageOne =
                    context.Messages.FirstOrDefault(x => x.Text == "Hi");

                Assert.IsNotNull(messageOne);
            }
        }
    }
}