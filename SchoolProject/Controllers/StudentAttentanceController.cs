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
    public class StudentAttentanceController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<StudentAttentance> cRUD_Repository;

        public StudentAttentanceController(ICRUD_Repository<StudentAttentance> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public List<StudentAttentance> Index()
        {
            List<StudentAttentance> StudentAttentancees = cRUD_Repository.Getall();

            return StudentAttentancees;
        }
        [HttpGet("{id:int}")]
        public StudentAttentance getbyID(int id)
        {
            StudentAttentance StudentAttentancees = cRUD_Repository.GetById(id);

            return StudentAttentancees;
        }
        [HttpPost]
        public int insert(StudentAttentance StudentAttentance)
        {
            return cRUD_Repository.Insert(StudentAttentance);
        }
        [HttpPut]
        public int Edit(StudentAttentance StudentAttentance)
        {
            return cRUD_Repository.Update(StudentAttentance);
        }
        [HttpDelete("{id:int}")]
        public int Delete(int id)
        {
            return cRUD_Repository.Delete(id);

        }

    }
}
