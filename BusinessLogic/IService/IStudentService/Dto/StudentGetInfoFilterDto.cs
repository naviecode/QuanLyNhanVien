namespace BusinessLogic.IService.IStudentService.Dto
{
    public class StudentGetInfoFilterDto
    {
        public int UserCurrentId { get; set; }
        public int StudentId { get;set; }
        public string StudentName { get;set;}
        public int DepartmentId { get;set; }
    }
}
