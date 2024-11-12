using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Permissions
    {
        [Key]
        public int PermissionID { get; set; }

        [Required]
        [MaxLength(50)]
        public string PermissionName { get; set; }

        public ICollection<RolePermissions> RolePermissions { get; set; } = new List<RolePermissions>();
    }
}
