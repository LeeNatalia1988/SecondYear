
using MessageWorker.DTO;
using NUnit.Framework.Legacy;
using UserWorker.Db;
using UserWorker.DbModels;
using UserWorker.DTO;

namespace Tests
{
    public class MyTest
    {
        [SetUp]
        public void Setup()
        {
            using (var context = new UserContext())
            {
                context.Users.RemoveRange(context.Users);

                context.SaveChanges();
            }
        }

        [TearDown]
        public void Teardown()
        {
            using (var context = new UserContext())
            {
                context.Users.RemoveRange(context.Users);

                context.SaveChanges();
            }
        }

        [Test]
        public async Task Test1()
        {
            var mock = new MockUserWorkerTest();
            var user1 = new UserViewModel() { Email = "1111@gmail.com", Password = "1234" };
            var user2 = new UserViewModel() { Email = "222@gmail.com", Password = "1234" };
            ClassicAssert.IsTrue(mock.AddAdmin(user1) == 0);
            mock.AddUser(user2);
            ClassicAssert.IsTrue(mock.UserCheck(user2) == RoleId.User);
            mock.DeleteUser("222@gmail.com");
            ClassicAssert.IsTrue(mock.UserCheck(user2) == RoleId.Admin);
        }

        [Test]
        public async Task Test2()
        {
            await Task.Delay(5000);
            var mock = new MockMessageWorkerTest();
            var messageToSend = new MessageViewModelToSend() { Text = "test", ToUser = "222@gmail.com" };
            mock.SendMessage(messageToSend, "1111@gmail.com");
            ClassicAssert.IsTrue(mock.ReceiveMessage("1111@gmail.com") != null);
        }
    }
}