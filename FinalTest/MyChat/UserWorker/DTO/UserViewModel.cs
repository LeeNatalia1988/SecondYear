using System.ComponentModel.DataAnnotations;

namespace UserWorker.DTO
{
    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
      
    }
}
