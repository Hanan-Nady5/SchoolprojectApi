using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SchoolProject.Controllers
{

//    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudyYearController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<StudyYear> cRUD_Repository;

        public StudyYearController(ICRUD_Repository<StudyYear> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public List<StudyYear> Index()
        {
            List<StudyYear> StudyYeares = cRUD_Repository.Getall();

            return StudyYeares;
        }
        [HttpGet("{id:int}")]
        public StudyYear getbyID(int id)
        {
            StudyYear StudyYeares = cRUD_Repository.GetById(id);

            return StudyYeares;
        }
        [HttpPost]
        public int insert(StudyYear StudyYear)
        {
            return cRUD_Repository.Insert(StudyYear);
        }
        [HttpPut]
        public int Edit(StudyYear StudyYear)
        {
            return cRUD_Repository.Update(StudyYear);
        }
        [HttpDelete("{id:int}")]
        public int Delete(int id)
        {
            return cRUD_Repository.Delete(id);

        }

    }
}
