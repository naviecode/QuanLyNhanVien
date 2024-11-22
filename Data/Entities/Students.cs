using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }      
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string HomeTown { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
        [Required]
        [ForeignKey("Class")]
        public int ClassId { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public Users User { get; set; }
        // Navigation property
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
