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
    public class LevelController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<Level> cRUD_Repository;

        public LevelController(ICRUD_Repository<Level> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public List<Level> Index()
        {
            List<Level> Leveles = cRUD_Repository.Getall();

            return Leveles;
        }
        [HttpGet("{id:int}")]
        public Level getbyID(int id)
        {
            Level Leveles = cRUD_Repository.GetById(id);

            return Leveles;
        }
        [HttpPost]
        public int insert(LevelDto levelDto)
        {
            Level level=new Level();
            level.Number = levelDto.Number;
            level.HistoryOfStudendID = levelDto.HistoryOfStudendID;
            return cRUD_Repository.Insert(level);
        }
        [HttpPut]
        public int Edit(LevelDto levelDto)
        {
            Level level = new Level();
            level.Id = levelDto.Id;
            level.Number = levelDto.Number;
            level.HistoryOfStudendID = levelDto.HistoryOfStudendID;
            return cRUD_Repository.Update(level);
        }
        [HttpDelete("{id:int}")]
        public int Delete(int id)
        {
            return cRUD_Repository.Delete(id);

        }

    }
}
