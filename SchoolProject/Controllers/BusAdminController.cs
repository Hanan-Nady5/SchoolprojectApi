using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Dtos;
using SchoolProject.Models;
using SchoolProject.Repository;
using System.Collections.Generic;

namespace SchoolProject.Controllers
{
    [Route("api/[controller]")]
    //[Authorize("admin")]
    [ApiController]
    public class BusAdminController : ControllerBase
    {
        private readonly Repository.ICrud_Repository1<BusAdmin> cRUD_Repository;
        public BusAdminController(ICrud_Repository1<BusAdmin> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public List<BusAdmin> Index()
        {
            List<BusAdmin> headManagers = cRUD_Repository.Getall();

            return headManagers;
        }
        [HttpGet("{id}")]
        public BusAdmin getbyID(string id)
        {
            BusAdmin busAdmin = cRUD_Repository.GetById(id);

            return busAdmin;
        }
        [HttpPost]
        public int insert(UserDto userDto)
        {
            BusAdmin busAdmin = new BusAdmin();
            busAdmin.UserName = userDto.userName;
            busAdmin.Email = userDto.email;
            busAdmin.Address = userDto.address;
            busAdmin.PhoneNumber = userDto.PhoneNumber;
            busAdmin.SSN = userDto.ssn;
            busAdmin.Image = userDto.image;
            return cRUD_Repository.Insert(busAdmin);
        }
        [HttpPut]
        public int Edit(BusAdmin busAdmin)
        {
             
           
            return cRUD_Repository.Update(busAdmin);
        }
        [HttpDelete("{id}")]
        public int Delete(string id)
        {
            return cRUD_Repository.Delete(id);

        }
    }
}
