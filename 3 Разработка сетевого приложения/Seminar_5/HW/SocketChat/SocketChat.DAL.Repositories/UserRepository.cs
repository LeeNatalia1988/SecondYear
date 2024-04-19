using Microsoft.EntityFrameworkCore;
using SocketChat.Common.Entities;
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
            await _chatContext.Users.AddAsync(user);
            await _chatContext.SaveChangesAsync();
        }
    }
}
