using SocketChat.Common.Entities;
using SocketChat.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketChat.BLL.Logic
{
    public class UserLogic : IUserLogic
    {
        public async void Add(User user)
        {
            await Task.Delay(1000);
            UserRepository.AddUser(user);
        }

        public async IAsyncEnumerable<User> GetAll()
        {
            await Task.Delay(1000);
            await foreach (var u in UserRepository.GetAll())
            {
                yield return u;
            }
        }
    }
}
