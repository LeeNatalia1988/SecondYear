using System.ComponentModel.DataAnnotations;

namespace UserWorker.DTO
{
    public class UserViewModelWithoutPassword
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
