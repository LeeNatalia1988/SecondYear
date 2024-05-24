using ChatApp;
using ChatDB;
using ChatNetwork;

namespace Chat.Test
{
    public class Tests
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
        public void Test1()
        {
            var mock = new MockMessagesSource();
            var server = new ChatServer(mock);
            mock.InitializeServer(server);
            server.Work();
            using (var context = new ChatContext())
            {
                Assert.IsTrue(context.Users.Count() == 2);

                var first = context.Users.FirstOrDefault(x => x.Name == "Ivan");
                var second = context.Users.FirstOrDefault(x => x.Name == "Alex");

                Assert.IsNotNull(first);
                Assert.IsNotNull(second);

                Assert.IsTrue(first.FromMessages.Count == 1);
                Assert.IsTrue(second.FromMessages.Count == 1);
                Assert.IsTrue(first.ToMessages.Count == 1);
                Assert.IsTrue(second.ToMessages.Count == 1);

                var messageOne =
                    context.Messages.FirstOrDefault(x => x.FromUser.Id == first.Id && x.ToUser.Id == second.Id);
                var messageTwo =
                    context.Messages.FirstOrDefault(x => x.FromUser.Id == second.Id && x.ToUser.Id == first.Id);

                Assert.AreEqual("Hello, Ivan", messageTwo.Text);
                Assert.AreEqual("Hello, Alex", messageOne.Text);
            }
        }

        [Test]
        public void Test2()
        {
            var mock = new MockMessagesClient();
            var client = new ChatClient("Alex", mock);
            var mock1 = new MockMessagesSource();
            var server = new ChatServer(mock1);
            mock1.InitializeServer(server);
            server.Work();
            Thread.Sleep(2000);
            
            mock.InitializeClient(client);
            client.Work();
            using (var context = new ChatContext())
            {
                var first = context.Users.FirstOrDefault(x => x.Name == "Alex");
                var second = context.Users.FirstOrDefault(x => x.Name == "Ivan");

                Assert.IsNotNull(first);
                Assert.IsNotNull(second);

                Assert.IsTrue(first.FromMessages.Count != 0);
                Assert.IsTrue(first.ToMessages.Count == 1);

                Assert.IsTrue(second.FromMessages.Count == 1);
                Assert.IsTrue(second.ToMessages.Count != 0);

                var messageOne = context.Messages.FirstOrDefault(x => x.FromUser.Id == first.Id && x.ToUser.Id == second.Id);
                Assert.IsNotNull(messageOne);
                Assert.AreEqual("Hello, Ivan", messageOne.Text);

                
                var messageClient = context.Messages.FirstOrDefault(x => x.Text == "Hi");
                Assert.IsNotNull(messageClient);
            }
        }
    }
}