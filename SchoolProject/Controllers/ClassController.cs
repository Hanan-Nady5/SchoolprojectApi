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
    public class ClassController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<Class> cRUD_Repository;
        public ClassController(ICRUD_Repository<Class> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public List<Class> Index()
        {
            List<Class> classes= cRUD_Repository.Getall();

            return classes;
        }
        [HttpGet("{id:int}")]
        public Class getbyID(int id)
        {
            Class Class = cRUD_Repository.GetById(id);

            return Class;
        }
        [HttpPost]
        public int insert(ClassDto classDto)
        {
            Class Class = new Class();
            Class.ChairNumber = classDto.chairNumber;
            Class.Name = classDto.name;
            Class.LevelID = classDto.LevelID;
            return cRUD_Repository.Insert(Class);
        }
        [HttpPut]
        public int Edit(ClassDto classDto)
        {
            Class Class = new Class();
            Class.Id = classDto.id;
            Class.ChairNumber = classDto.chairNumber;
            Class.Name = classDto.name;
            Class.LevelID = classDto.LevelID;
            return cRUD_Repository.Update(Class);
        }
        [HttpDelete("{id:int}")]
        public int Delete(int id)
        {
            return cRUD_Repository.Delete(id);

        }
        [HttpGet("/classoflevel")]
        public List<Class> getallstdbylvlid(int lvlid)
        {
            List<Class> Students = cRUD_Repository.Getall().Where(std => std.LevelID == lvlid).ToList();
            return Students;


        }
    }
}
