using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Dtos;
using SchoolProject.Models;
using SchoolProject.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SchoolProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<Course> cRUD_Repository;
        public CourseController(ICRUD_Repository<Course> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public List<Course> Index()
        {
            List<Course> courses = cRUD_Repository.Getall();

            return courses;
        }
        [HttpGet("{id}")]
        public Course getbyID(int id)
        {
            Course Course = cRUD_Repository.GetById(id);

            return Course;
        }
        [HttpPost]
        public int insert(CourseDto courseDto)
        {
            Course course = new Course();
            course.Name= courseDto.name;
            course.LevelID= courseDto.levelID;
            return cRUD_Repository.Insert(course);
        }
        [HttpPut]
        public int Edit(CourseDto courseDto)
        {
            Course course = new Course();
            course.Id = courseDto.id;
            course.Name = courseDto.name;
            course.LevelID = courseDto.levelID;
            return cRUD_Repository.Update(course);
        }
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return cRUD_Repository.Delete(id);

        }
        [HttpGet("/Courseoflevel")]
        public List<Course> getallstdbylvlid(int lvlid)
        {
            List<Course> courses = cRUD_Repository.Getall().Where(std => std.LevelID == lvlid).ToList();
            return courses;


        }
    }
}
