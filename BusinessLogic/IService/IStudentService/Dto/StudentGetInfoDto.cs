namespace BusinessLogic.IService.IStudentService.Dto
{
    public class StudentGetInfoDto
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Country { get; set; }
        public int UserId { get; set; }
        public string DepartmentName { get; set; }
        public string ClassName { get; set; }
        public int Year { get; set; }
    }
}
