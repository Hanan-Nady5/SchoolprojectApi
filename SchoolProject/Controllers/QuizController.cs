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
    public class QuizController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<Quiz> cRUD_Repository;

        public QuizController(ICRUD_Repository<Quiz> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public List<Quiz> Index()
        {
            List<Quiz> Quizes = cRUD_Repository.Getall();

            return Quizes;
        }
        [HttpGet("{id:int}")]
        public Quiz getbyID(int id)
        {
            Quiz Quizes = cRUD_Repository.GetById(id);

            return Quizes;
        }
        [HttpPost]
        public int insert(Quiz Quiz)
        {
            return cRUD_Repository.Insert(Quiz);
        }
        [HttpPut]
        public int Edit(Quiz Quiz)
        {
            return cRUD_Repository.Update(Quiz);
        }
        [HttpDelete("{id:int}")]
        public int Delete(int id)
        {
            return cRUD_Repository.Delete(id);

        }

    }
}
