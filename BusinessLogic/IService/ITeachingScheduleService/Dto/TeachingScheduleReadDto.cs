using Data.Entities;

namespace BusinessLogic.IService.ITeachingScheduleService.Dto
{
    public class TeachingScheduleReadDto
    {
        public int Id { get; set; }
        public int CourseScheduleId { get; set; }
        public string CourseName { get; set; }
        public string StartAndEndTime { get; set; }
        public DateTime Date { get; set; }
        public int? FacultyScheduleId { get; set; }
        public string FactlyName { get; set; }
        public string Room { get; set; }
        public Course Course { get; set; }
        public Faculty Faculty { get; set; }
    }
}
