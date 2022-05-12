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
    public class CourseScheduleDetailsController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<CourseScheduleDetails> cRUD_Repository;

        public CourseScheduleDetailsController(ICRUD_Repository<CourseScheduleDetails> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public List<CourseScheduleDetails> Index()
        {
            List<CourseScheduleDetails> CourseScheduleDetailses = cRUD_Repository.Getall();

            return CourseScheduleDetailses;
        }
        [HttpGet("{id}")]
        public CourseScheduleDetails getbyID(int id)
        {
            CourseScheduleDetails CourseScheduleDetailses = cRUD_Repository.GetById(id);

            return CourseScheduleDetailses;
        }
        [HttpPost]
        public int insert(CourseScheduleDetailsDto courseScheduleDetailsDto)
        {
            CourseScheduleDetails courseScheduleDetails=new CourseScheduleDetails();
            courseScheduleDetails.StartTime= courseScheduleDetailsDto.StartTime;
            courseScheduleDetails.EndTime= courseScheduleDetailsDto.EndTime;
            courseScheduleDetails.CourseSchedule_ID= courseScheduleDetailsDto.CourseSchedule_ID;
            courseScheduleDetails.ApplicationUserID=courseScheduleDetailsDto.ApplicationUserID;
            return cRUD_Repository.Insert(courseScheduleDetails);
        }
        [HttpPut]
        public int Edit(CourseScheduleDetailsDto courseScheduleDetailsDto)
        {
            CourseScheduleDetails courseScheduleDetails = new CourseScheduleDetails();
            courseScheduleDetails.Id = courseScheduleDetailsDto.Id;
            courseScheduleDetails.StartTime = courseScheduleDetailsDto.StartTime;
            courseScheduleDetails.EndTime = courseScheduleDetailsDto.EndTime;
            courseScheduleDetails.CourseSchedule_ID = courseScheduleDetailsDto.CourseSchedule_ID;
            courseScheduleDetails.ApplicationUserID = courseScheduleDetailsDto.ApplicationUserID;

            return cRUD_Repository.Update(courseScheduleDetails);
        }
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return cRUD_Repository.Delete(id);

        }

    }
}
