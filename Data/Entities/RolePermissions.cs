using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class RolePermissions
    {
        [Required]
        [ForeignKey("Role")]
        public int RoleID { get; set; }

        [Required]
        [ForeignKey("Permission")]
        public int PermissionID { get; set; }

        [Key, Column(Order = 0)]
        public int Id { get; set; }

        public Roles Role { get; set; }
        public Permissions Permission { get; set; }
    }
}
