using SchoolProject.Models;
using System.Collections.Generic;

namespace SchoolProject.Dtos
{
    public class CourseDto
    {
        public int id { get; set; }
        public string  name { get; set; }
        public int levelID { get; set; }
        //public List<Teacher> teachers { get; set; }
    }
}
