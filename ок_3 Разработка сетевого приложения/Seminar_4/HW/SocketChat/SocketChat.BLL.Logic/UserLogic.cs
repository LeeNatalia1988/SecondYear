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
        public async Task AddAsync(User user)
        {
            await UserRepository.AddUser(user);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return (List<User>)UserRepository.GetAll();
        }
    }
}

