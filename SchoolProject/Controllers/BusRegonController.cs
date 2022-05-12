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

    //  [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BusRegonController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<BusRegon> cRUD_Repository;

        public BusRegonController(ICRUD_Repository<BusRegon> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public List<BusRegon> Index()
        {
            List<BusRegon> busRegons = cRUD_Repository.Getall();

            return busRegons;
        }
        [HttpGet("{id}")]
        public BusRegon getbyID(int id)
        {
            BusRegon busRegons = cRUD_Repository.GetById(id);

            return busRegons;
        }

        [HttpPost]
        public int insert(RegonDto regonDto)
        {
            BusRegon busRegon= new BusRegon();
            busRegon.address = regonDto.address;
            busRegon.RegonName = regonDto.RegonName;    
           
            return cRUD_Repository.Insert(busRegon);
        }
        [HttpPut]
        public int Edit(RegonDto regonDto)
        {
            BusRegon busRegon = new BusRegon();
            busRegon.Id = regonDto.Id;
            busRegon.address = regonDto.address;
            busRegon.RegonName = regonDto.RegonName;
            return cRUD_Repository.Update(busRegon);
        }
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return cRUD_Repository.Delete(id);

        }

    }
}
