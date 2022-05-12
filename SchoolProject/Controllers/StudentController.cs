using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Dtos;
using SchoolProject.Models;
using SchoolProject.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SchoolProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly Repository.ICrud_Repository1<Student> cRUD_Repository;
        ///   private readonly IStdRepository stdRepository;
        Context _context = new Context();
        public StudentController(ICrud_Repository1<Student> cRUD_Repository)//, IStdRepository stdRepository)
        {
            this.cRUD_Repository = cRUD_Repository;
            // this.stdRepository = stdRepository;
        }
        [HttpGet]
        public List<Student> Index()
        {
            List<Student> Students = cRUD_Repository.Getall();

            return Students;
        }
        [HttpGet("{id}")]
        public Student getbyID(string id)
        {
            Student Student = cRUD_Repository.GetById(id);

            return Student;
        }
        [HttpPost]
        public int insert(UserDto userDto)
        {
            Student Student = new Student();
            Student.UserName = userDto.userName;
            Student.Email = userDto.email;
            Student.Address = userDto.address;
            Student.PhoneNumber = userDto.PhoneNumber;
            Student.SSN = userDto.ssn;
            //Student.Holiday = userDto.Holiday;
            //Student.AbsenceDays = userDto.AbsenceDays;
            //Student.busStudentID = userDto.busStudentID;
            //Student.LevelId = userDto.LevelID;
            Student.Image = userDto.image;
            return cRUD_Repository.Insert(Student);
        }
        [HttpPut]
        public int Edit(UserDto userDto)
        {
            Student Student = new Student();
            Student.Id = userDto.Id;
            Student.UserName = userDto.userName;
            Student.Email = userDto.email;
            Student.Address = userDto.address;
            Student.PhoneNumber = userDto.PhoneNumber;
            Student.SSN = userDto.ssn;
            Student.Holiday = userDto.Holiday;
            Student.AbsenceDays = userDto.AbsenceDays;
            Student.busStudentID = userDto.busStudentID;
            Student.Image = userDto.image;
            return cRUD_Repository.Update(Student);
        }
        [HttpDelete("{id}")]
        public int Delete(string id)
        {
            return cRUD_Repository.Delete(id);

        }
        [HttpGet("/stdoflevel")]
        public List<Student> getallstdbylvlid(int lvlid)
        {
            List<Student> Students = cRUD_Repository.Getall().Where(std => std.LevelId == lvlid).ToList();
            return Students;


        }

    }
}