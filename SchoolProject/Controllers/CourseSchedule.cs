using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Dtos;
using SchoolProject.Models;
using SchoolProject.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SchoolProject.Controllers
{

//    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseScheduleController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<CourseSchedule> cRUD_Repository;

        public CourseScheduleController(ICRUD_Repository<CourseSchedule> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public List<CourseSchedule> Index()
        {
            List<CourseSchedule> CourseSchedulees = cRUD_Repository.Getall();

            return CourseSchedulees;
        }
        [HttpGet("{id}")]
        public CourseSchedule getbyID(int id)
        {
            CourseSchedule CourseSchedulees = cRUD_Repository.GetById(id);

            return CourseSchedulees;
        }
        [HttpPost]
        public int insert(CourseScheduleDto courseScheduleDto)
        {
            CourseSchedule courseSchedule = new CourseSchedule();
            courseSchedule.Term = courseScheduleDto.Term;
            courseSchedule.Level_ID = courseScheduleDto.Level_ID;
            courseSchedule.Class_ID=courseScheduleDto.Class_ID;
            return cRUD_Repository.Insert(courseSchedule);
        }
        [HttpPut]
        public int Edit(CourseScheduleDto courseScheduleDto)
        {
            CourseSchedule courseSchedule = new CourseSchedule();
            courseSchedule.Id = courseSchedule.Id;
            courseSchedule.Term = courseScheduleDto.Term;
            courseSchedule.Level_ID = courseScheduleDto.Level_ID;
            courseSchedule.Class_ID = courseScheduleDto.Class_ID;
            return cRUD_Repository.Update(courseSchedule);
        }
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return cRUD_Repository.Delete(id);

        }

    }
}
