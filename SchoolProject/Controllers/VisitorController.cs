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
    public class VisitorController : ControllerBase
    {
        private readonly Repository.ICrud_Repository1<Visitior> cRUD_Repository;
        public VisitorController(ICrud_Repository1<Visitior> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public List<Visitior> Index()
        {
            List<Visitior> visitiors= cRUD_Repository.Getall();

            return visitiors;
        }
        [HttpGet("{id}")]
        public Visitior getbyID(string id)
        {
            Visitior visitior = cRUD_Repository.GetById(id);

            return visitior;
        }
        [HttpPost]
        public int insert(UserDto userDto)
        {
            Visitior visitior=new Visitior();
            visitior.UserName = userDto.userName;
            visitior.Email = userDto.email;
            visitior.Address = userDto.address;
            visitior.PhoneNumber = userDto.PhoneNumber;
            visitior.SSN = userDto.ssn;
            visitior.Gender=userDto.gender;
            visitior.Image = userDto.image;
            return cRUD_Repository.Insert(visitior);
        }
       
        [HttpPut]
        public int Edit(UserDto userDto)
        {
            Visitior visitior = new Visitior();
            visitior.Id = userDto.Id;
            visitior.UserName = userDto.userName;
            visitior.Email = userDto.email;
            visitior.Address = userDto.address;
            visitior.PhoneNumber = userDto.PhoneNumber;
            visitior.SSN = userDto.ssn;
            visitior.Gender = userDto.gender;
            visitior.Image= userDto.image;
            return cRUD_Repository.Update( visitior);
        }
        [HttpDelete("{id}")]
        public int Delete(string id)
        {
            return cRUD_Repository.Delete(id);

        }

    }
}
