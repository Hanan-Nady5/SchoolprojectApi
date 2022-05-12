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
    public class ExamScheduleDetailsController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<ExamScheduleDetails > cRUD_Repository;

        public ExamScheduleDetailsController(ICRUD_Repository<ExamScheduleDetails > cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public List<ExamScheduleDetails > Index()
        {
            List<ExamScheduleDetails > ExamScheduleDetails = cRUD_Repository.Getall();

            return ExamScheduleDetails ;
        }
        [HttpGet("{id}")]
        public ExamScheduleDetails  getbyID(int id)
        {
            ExamScheduleDetails  ExamScheduleDetails  = cRUD_Repository.GetById(id);

            return ExamScheduleDetails ;
        }
        [HttpPost]
        public int insert(ExamScheduleDetailsDto  examScheduleDetailsDto )
        {
            ExamScheduleDetails examScheduleDetails = new ExamScheduleDetails();
            examScheduleDetails.StartTime = examScheduleDetailsDto.StartTime;
            examScheduleDetails.EndTime = examScheduleDetailsDto.EndTime;
            examScheduleDetails.Course_ID = examScheduleDetailsDto.Course_ID;
            examScheduleDetails.TeacherID = examScheduleDetailsDto.TeacherID;
            examScheduleDetails.ExamSchedule_ID = examScheduleDetailsDto.ExamSchedule_ID;


            return cRUD_Repository.Insert(examScheduleDetails);
        }
        [HttpPut]
        public int Edit(ExamScheduleDetailsDto examScheduleDetailsDto)
        {
            ExamScheduleDetails examScheduleDetails = new ExamScheduleDetails();
            examScheduleDetails.Id = examScheduleDetailsDto.Id;
            examScheduleDetails.StartTime = examScheduleDetailsDto.StartTime;
            examScheduleDetails.EndTime = examScheduleDetailsDto.EndTime;
            examScheduleDetails.Course_ID = examScheduleDetailsDto.Course_ID;
            examScheduleDetails.TeacherID = examScheduleDetailsDto.TeacherID;
            examScheduleDetails.ExamSchedule_ID = examScheduleDetailsDto.ExamSchedule_ID;

            return cRUD_Repository.Update(examScheduleDetails );
        }
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return cRUD_Repository.Delete(id);

        }

    }
}
