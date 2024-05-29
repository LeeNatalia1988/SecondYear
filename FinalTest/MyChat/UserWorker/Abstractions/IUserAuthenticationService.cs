using UserWorker.AuthorizationModels;
using UserWorker.DTO;

namespace UserWorker.Abstractions
{
    public interface IUserAuthenticationService
    {
        UserModel Authenticate(UserViewModel userModel);
    }
}
