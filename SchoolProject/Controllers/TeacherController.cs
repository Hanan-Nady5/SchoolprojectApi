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
    public class TeacherController : ControllerBase
    {
        private readonly Repository.ICrud_Repository1<Teacher> cRUD_Repository;
        public TeacherController(ICrud_Repository1<Teacher> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public List<Teacher> Index()
        {
            List<Teacher> teachers = cRUD_Repository.Getall();

            return teachers;
        }
        [HttpGet("{id}")]
        public Teacher getbyID(string id)
        {
            Teacher teacher = cRUD_Repository.GetById(id);

            return teacher;
        }
        [HttpPost]
        public int insert(UserDto userDto)
        {
            Teacher teacher = new Teacher();
            teacher.UserName = userDto.userName;
            teacher.Email = userDto.email;
            teacher.Address = userDto.address;
            teacher.PhoneNumber = userDto.PhoneNumber;
            teacher.SSN = userDto.ssn;
            teacher.busTeacherID=userDto.busTeacherID;
            teacher.Image = userDto.image;
            return cRUD_Repository.Insert(teacher);
        }
        [HttpPut]
        public int Edit(UserDto userDto)
        {
            Teacher teacher = new Teacher();
            teacher.Id = userDto.Id;
            teacher.UserName = userDto.userName;
            teacher.Email = userDto.email;
            teacher.Address = userDto.address;
            teacher.PhoneNumber = userDto.PhoneNumber;
            teacher.SSN = userDto.ssn;
            teacher.busTeacherID = userDto.busTeacherID;
            teacher.Image = userDto.image;
            return cRUD_Repository.Update(teacher);
        }
        [HttpDelete("{id}")]
        public int Delete(string id)
        {
            return cRUD_Repository.Delete(id);

        }
    }
}
