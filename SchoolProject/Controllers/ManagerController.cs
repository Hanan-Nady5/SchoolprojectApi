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
    public class ManagerController : ControllerBase
    {
        private readonly Repository.ICrud_Repository1<Manager> cRUD_Repository;
        public ManagerController(ICrud_Repository1<Manager> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public List<Manager> Index()
        {
            List<Manager> managers = cRUD_Repository.Getall();

            return managers;
        }
        [HttpGet("{id}")]
        public Manager getbyID(string id)
        {
            Manager manager = cRUD_Repository.GetById(id);

            return manager;
        }
        [HttpPost]
        public int insert(UserDto userDto)
        {
            Manager manager = new Manager();
            manager.UserName = userDto.userName;
            manager.Email = userDto.email;
            manager.Address = userDto.address;
            manager.PhoneNumber = userDto.PhoneNumber;
            manager.SSN = userDto.ssn;
            manager.Image = userDto.image;
            return cRUD_Repository.Insert(manager);
        }
        [HttpPut]
        public int Edit(UserDto userDto)
        {
            Manager manager = new Manager();
            manager.Id = userDto.Id;
            manager.UserName = userDto.userName;
            manager.Email = userDto.email;
            manager.Address = userDto.address;
            manager.PhoneNumber = userDto.PhoneNumber;
            manager.SSN = userDto.ssn;
            manager.Image = userDto.image;
            return cRUD_Repository.Update(manager);
        }
        [HttpDelete("{id}")]
        public int Delete(string id)
        {
            return cRUD_Repository.Delete(id);

        }
    }
}
