using SocketChat.Common.Entities;

namespace SocketChat.DAL.Repositories
{
    public static class UserRepository
    {
        private static List<User> users = new List<User>();

        public static async IAsyncEnumerable<User> GetAll()
        {
            await Task.Delay(1000); 
            foreach (var u in users)
            {
                if (u != null)
                {
                    yield return u;
                }
            }
        }

        public static async void AddUser(User user)
        {
            await Task.Delay(1000);
            users.Add(user);
        }
    }
}
