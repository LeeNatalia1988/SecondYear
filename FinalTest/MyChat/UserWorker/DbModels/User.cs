using System.ComponentModel.DataAnnotations;

namespace UserWorker.DbModels
{
    public class User
    {
        public Guid? Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public RoleId RoleId { get; set; }
        public virtual Role Role { get; set; }

    }
}
