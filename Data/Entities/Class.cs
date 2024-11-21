using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Class
    {
        public int Id { get; set; } 
        [Required]
        public string ClassName { get; set; }
        public int DepartmentId { get; set; } 
    }
}
