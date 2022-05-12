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
    public class HeadMangerController : ControllerBase
    {
        private readonly Repository.ICrud_Repository1<HeadManager> cRUD_Repository;
        public HeadMangerController(ICrud_Repository1<HeadManager> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public List<HeadManager> Index()
        {
            List<HeadManager> headManagers = cRUD_Repository.Getall();
            //List<UserDto> userDtos = new List<UserDto>();
            //for(int i = 0; i < headManagers.Count; i++)
            //{
                
            //    userDtos[i].name = headManagers[i].UserName ;
            //    userDtos[i].email = headManagers[i].Email ;
            //    userDtos[i].address = headManagers[i].Address ;
            //    userDtos[i].phone = headManagers[i].PhoneNumber ;
            //    userDtos[i].ssn = headManagers[i].SSN ;
            //    userDtos[i].HeadManagerebusId = headManagers[i].HeadManagerebusId ;

            //}
            //return userDtos;
            return headManagers;
        }
        [HttpGet("{id}")]
        public HeadManager getbyID(string id)
        {
            HeadManager headManager = cRUD_Repository.GetById(id);

            return headManager;
        }
        [HttpPost]
        public int insert(UserDto userDto)
        {
            HeadManager headManager = new HeadManager();
            headManager.UserName = userDto.userName;
            headManager.Email = userDto.email;
            headManager.Address = userDto.address;
            headManager.PhoneNumber = userDto.PhoneNumber;
            headManager.SSN = userDto.ssn;
            headManager.HeadManagerebusId = userDto.HeadManagerebusId;
            headManager.Image = userDto.image;
            return cRUD_Repository.Insert(headManager);
        }
        [HttpPut]
        public int Edit(UserDto userDto)
        {
            HeadManager headManager = new HeadManager();
            headManager.Id = userDto.Id;
            headManager.UserName = userDto.userName;
            headManager.Email = userDto.email;
            headManager.Address = userDto.address;
            headManager.PhoneNumber = userDto.PhoneNumber;
            headManager.SSN = userDto.ssn;
            headManager.HeadManagerebusId = userDto.HeadManagerebusId;
            headManager.Image=userDto.image;
            return cRUD_Repository.Update(headManager);
        }
        [HttpDelete("{id}")]
        public int Delete(string id)
        {
            return cRUD_Repository.Delete(id);

        }
    }
}
