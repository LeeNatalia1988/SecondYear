using System.ComponentModel.DataAnnotations;

namespace UserWorker.DbModels
{
    public class Role
    {
        public RoleId RoleId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
    }
}
