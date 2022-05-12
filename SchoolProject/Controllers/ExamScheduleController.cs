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
    public class ExamScheduleController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<ExamSchedule> cRUD_Repository;

        public ExamScheduleController(ICRUD_Repository<ExamSchedule> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public List<ExamSchedule> Index()
        {
            List<ExamSchedule> ExamSchedulees = cRUD_Repository.Getall();

            return ExamSchedulees;
        }
        [HttpGet("{id}")]
        public ExamSchedule getbyID(int id)
        {
            ExamSchedule ExamSchedulees = cRUD_Repository.GetById(id);

            return ExamSchedulees;
        }
        [HttpPost]
        public int insert(ExamScheduleDto examScheduleDto)
        {
            ExamSchedule examSchedule = new ExamSchedule();
            examSchedule.Term=examScheduleDto.Term;
            examSchedule.Level_ID=examScheduleDto.Level_ID;
            return cRUD_Repository.Insert(examSchedule);
        }
        [HttpPut]
        public int Edit(ExamScheduleDto examScheduleDto)
        {
            ExamSchedule examSchedule = new ExamSchedule();
            examSchedule.Id = examScheduleDto.Id;
            examSchedule.Term = examScheduleDto.Term;
            examSchedule.Level_ID = examScheduleDto.Level_ID;
            return cRUD_Repository.Update(examSchedule);
        }
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return cRUD_Repository.Delete(id);

        }

    }
}
