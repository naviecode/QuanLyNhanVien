using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int DepartmentID { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public Users User { get; set; }
        public Department Department { get; set; }
        public ICollection<ClassSection> Classes { get; set; }
    }
}
