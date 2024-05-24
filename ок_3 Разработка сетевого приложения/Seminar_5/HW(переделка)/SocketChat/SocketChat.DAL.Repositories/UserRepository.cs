using Microsoft.EntityFrameworkCore;
using SocketChat.Common.Entities;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;


namespace SocketChat.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ChatContext _chatContext;
        public UserRepository(ChatContext chatContext)
        {
            _chatContext = chatContext;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _chatContext.Users.Include(m => m.Messages).ToListAsync();
        }

        public async Task AddUsersAsync(User user)
        {
            if (_chatContext.Users.Any(name => name.Name == user.Name))
            {
                SignalRMessage message = new();
                message.MessageText = user.Messages.First().MessageText;
                var findUser = _chatContext.Users.Where(name => name.Name == user.Name);
                message.UserId = findUser.First().Id;
                
                _chatContext.Messages.Add(message);
                
            }
            else
            {
                await _chatContext.Users.AddAsync(user);
            }
            
            await _chatContext.SaveChangesAsync();
        }
    }
}
