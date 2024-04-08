using SocketChat.Common.Entities;

namespace SocketChat.DAL.Repositories
{
    public static class UserRepository
    {
        private static List<User> users = new List<User>();

        public static List<User> GetAll()
        {
            return users;
        }

        public static async void AddUser(User user)
        {
            await Task.Delay(1000);
            users.Add(user);
        }
    }
}
