using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        [ForeignKey("Role")]
        public int RoleID { get; set; }

        public Roles Role { get; set; }

        public Students Student { get; set; }

        public Faculty Faculty { get; set; }
    }
}
