using Data.Entities;

namespace BusinessLogic.IService.ITeachingScheduleService.Dto
{
    public class TeachingScheduleCreateDto
    {
        public int CourseScheduleId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public string StartAndEndTime { get; set; }
        public DateTime Date { get; set; }
        public int? FacultyScheduleId { get; set; }
        public Course Course { get; set; }
        public Faculty Faculty { get; set; }
    }
}
