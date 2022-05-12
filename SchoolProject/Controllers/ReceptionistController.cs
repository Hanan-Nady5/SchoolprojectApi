using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Dtos;
using SchoolProject.Models;
using SchoolProject.Repository;
using System.Collections.Generic;

namespace SchoolProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptionistController : ControllerBase
    {
        private readonly Repository.ICrud_Repository1<Receptionist> cRUD_Repository;
        public ReceptionistController(ICrud_Repository1<Receptionist> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public List<Receptionist> Index()
        {
            List<Receptionist> receptionists = cRUD_Repository.Getall();

            return receptionists;
        }
        [HttpGet("{id}")]
        public Receptionist getbyID(string id)
        {
            Receptionist receptionist = cRUD_Repository.GetById(id);

            return receptionist;
        }
        [HttpPost]
        public int insert(UserDto userDto)
        {
            Receptionist receptionist = new Receptionist();
            receptionist.UserName = userDto.userName;
            receptionist.Email = userDto.email;
            receptionist.Address = userDto.address;
            receptionist.PhoneNumber = userDto.PhoneNumber;
            receptionist.SSN = userDto.ssn;
            receptionist.Image = userDto.image;
            return cRUD_Repository.Insert(receptionist);
        }
        [HttpPut]
        public int Edit(UserDto userDto)
        {
            Receptionist receptionist = new Receptionist();
            receptionist.Id = userDto.Id;
            receptionist.UserName = userDto.userName;
            receptionist.Email = userDto.email;
            receptionist.Address = userDto.address;
            receptionist.PhoneNumber = userDto.PhoneNumber;
            receptionist.SSN = userDto.ssn;
            receptionist.Image = userDto.image;
            return cRUD_Repository.Update(receptionist);
        }
        [HttpDelete("{id}")]
        public int Delete(string id)
        {
            return cRUD_Repository.Delete(id);

        }
    }
}
