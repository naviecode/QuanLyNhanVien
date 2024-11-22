namespace BusinessLogic.IService.ICourseService.Dto
{
    public class CourseNearCloseDto
    {
        public string CourseName { get; set; }
        public DateTime EndRegisterDate { get; set; }
        public int MaxAmountRegist { get; set; }
        public string Status { get; set; }
    }
}
