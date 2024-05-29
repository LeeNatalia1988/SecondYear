using UserWorker.DbModels;
using UserWorker.DTO;

namespace UserWorker.Abstractions
{
    public interface IUserRepository
    {
        public int AddAdmin(UserViewModel userViewModel);
        public int AddUser(UserViewModel userViewModel);
        public IEnumerable<UserViewModelWithoutPassword> GetUsers();
        public int DeleteUser(string email);
        public Guid? GetUserID(string email);

        public RoleId UserCheck(UserViewModel userViewModel);
    }
}
