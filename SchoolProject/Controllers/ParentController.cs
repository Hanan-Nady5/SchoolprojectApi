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
    public class ParentController : ControllerBase
    {
        private readonly Repository.ICrud_Repository1<Parent> cRUD_Repository;
        public ParentController(ICrud_Repository1<Parent> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public List<Parent> Index()
        {
            List<Parent> parents = cRUD_Repository.Getall();

            return parents;
        }
        [HttpGet("{id}")]
        public Parent getbyID(string id)
        {
            Parent parent = cRUD_Repository.GetById(id);

            return parent;
        }
        [HttpPost]
        public int insert(UserDto userDto)
        {
            Parent parent = new Parent();
            parent.UserName = userDto.userName;
            parent.Email = userDto.email;
            parent.Address = userDto.address;
            parent.PhoneNumber = userDto.PhoneNumber;
            parent.SSN = userDto.ssn;
            parent.Image = userDto.image;
            return cRUD_Repository.Insert(parent);
        }
        [HttpPut]
        public int Edit(UserDto userDto)
        {
            Parent parent = new Parent();
            parent.Id = userDto.Id;
            parent.UserName = userDto.userName;
            parent.Email = userDto.email;
            parent.Address = userDto.address;
            parent.PhoneNumber = userDto.PhoneNumber;
            parent.SSN = userDto.ssn;
            parent.Image = userDto.image;
            return cRUD_Repository.Update(parent);
        }
        [HttpDelete("{id}")]
        public int Delete(string id)
        {
            return cRUD_Repository.Delete(id);

        }
    }
}
