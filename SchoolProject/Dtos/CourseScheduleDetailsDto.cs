using System;

namespace SchoolProject.Dtos
{
    public class CourseScheduleDetailsDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Course_ID { get; set; }
        public int CourseSchedule_ID { get; set; }
        public string ApplicationUserID { get; set; }
    }
}
