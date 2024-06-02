using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UserWorker.DTO
{
    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Слишком короткий пароль.")]
        public string Password { get; set; }
    }
}
