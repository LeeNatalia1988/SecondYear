using UserWorker.Abstractions;
using UserWorker.DTO;

namespace UserWorker.AuthorizationModels
{
    public class AuthenticationMock : IUserAuthenticationService
    {
        public UserModel Authenticate(UserViewModel model)
        {
            if (model.Email == "admin@gmail.com" && model.Password == "admin")
            {
                return new UserModel { Email = model.Email, Password = model.Password, Role = UserRole.Admin };
            }
            if (model.Email == "user@gmail.com" && model.Password == "user")
            {
                return new UserModel { Email = model.Email, Password = model.Password, Role = UserRole.User };
            }
            return null;
        }
    }
}
