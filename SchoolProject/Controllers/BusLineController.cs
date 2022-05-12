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
    public class BusLineController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<BusLine> cRUD_Repository;

        public BusLineController(ICRUD_Repository<BusLine> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public List<BusLine> Index()
        {
            List<BusLine> BusLinees = cRUD_Repository.Getall();

            return BusLinees;
        }
        [HttpGet("{id:int}")]
        public BusLine getbyID(int id)
        {
            BusLine BusLinees = cRUD_Repository.GetById(id);

            return BusLinees;
        }
        [HttpPost]
        public int insert(BusLineDto busLineDto)
        {
            BusLine busLine=new BusLine();
            busLine.address = busLineDto.address;
            busLine.LineName = busLineDto.LineName;
           
            return cRUD_Repository.Insert(busLine);
        }
        [HttpPut]
        public int Edit(BusLineDto busLineDto)
        {
            BusLine busLine = new BusLine();
            busLine.Id = busLineDto.Id;
            busLine.address = busLineDto.address;
            busLine.LineName = busLineDto.LineName;
            return cRUD_Repository.Update(busLine);
        }
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return cRUD_Repository.Delete(id);

        }

    }
}
