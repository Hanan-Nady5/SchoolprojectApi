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
    public class BusController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<Bus> cRUD_Repository;

        public BusController(ICRUD_Repository<Bus> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public List<Bus> Index()
        {
            List<Bus> buses = cRUD_Repository.Getall();

            return buses;
        }
        [HttpGet("{id:int}")]
        public Bus getbyID(int id)
        {
            Bus buses = cRUD_Repository.GetById(id);

            return buses;
        }
        [HttpPost]
        public int insert(BusDto busTdo)
        {
            Bus bus = new Bus();
            bus.BusNumber = busTdo.BusNumber;
            bus.BusChairNumber = busTdo.BusChairNumber;
            bus.BusDriverName = busTdo.BusDriverName;
            bus.ApplicationUserID = busTdo.ApplicationUserID;
            bus.BusLineID = busTdo.BusLineID;
            bus.Users = busTdo.Users;

            return cRUD_Repository.Insert(bus);
        }
        [HttpPut]
        public int Edit(BusDto busTdo)
        {

            Bus bus = new Bus();
            bus.Id = busTdo.Id;
            bus.BusNumber = busTdo.BusNumber;
            bus.BusChairNumber = busTdo.BusChairNumber;
            bus.BusDriverName = busTdo.BusDriverName;
            bus.ApplicationUserID = busTdo.ApplicationUserID;
            bus.BusLineID = busTdo.BusLineID;
            bus.Users = busTdo.Users;
            return cRUD_Repository.Update(bus);
        }
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return cRUD_Repository.Delete(id);

        }

    }
}
