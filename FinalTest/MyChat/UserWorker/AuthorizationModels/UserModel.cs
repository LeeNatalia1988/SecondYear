using System.ComponentModel.DataAnnotations;

namespace UserWorker.AuthorizationModels
{
    public class UserModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
