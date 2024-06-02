using System.ComponentModel.DataAnnotations;

namespace UserWorker.AuthorizationModels
{
    public class LoginModel
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
