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
    public class StaffAttentanceController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<StaffAttentance> cRUD_Repository;

        public StaffAttentanceController(ICRUD_Repository<StaffAttentance> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public List<StaffAttentance> Index()
        {
            List<StaffAttentance> StaffAttentancees = cRUD_Repository.Getall();

            return StaffAttentancees;
        }
        [HttpGet("{id:int}")]
        public StaffAttentance getbyID(int id)
        {
            StaffAttentance StaffAttentancees = cRUD_Repository.GetById(id);

            return StaffAttentancees;
        }
        [HttpPost]
        public int insert(StaffAttentance StaffAttentance)
        {
            return cRUD_Repository.Insert(StaffAttentance);
        }
        [HttpPut]
        public int Edit(StaffAttentance StaffAttentance)
        {
            return cRUD_Repository.Update(StaffAttentance);
        }
        [HttpDelete("{id:int}")]
        public int Delete(int id)
        {
            return cRUD_Repository.Delete(id);

        }

    }
}
