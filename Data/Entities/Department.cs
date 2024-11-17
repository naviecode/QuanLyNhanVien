using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DepartmentName { get; set; }

        public ICollection<Faculty> Faculties { get; set; }
    }
}
