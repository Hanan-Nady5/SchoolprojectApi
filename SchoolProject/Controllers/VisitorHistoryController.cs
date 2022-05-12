using JsonBasedLocalization.Api.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;
using System.Collections.Generic;

namespace SchoolProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorHistoryController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<VistorHitory> cRUD_Repository;
        
        Context Context;
        public VisitorHistoryController(ICRUD_Repository<VistorHitory> cRUD_Repository,Context context)
        {
            this.cRUD_Repository = cRUD_Repository;
            this.Context = context;
        }
        [HttpPost]
        public int insert(Visitor_HistoryDTo Visitor_HistoryDTo)
        {
            VistorHitory VistorHitory = new VistorHitory();
            VistorHitory.Visit_Date = Visitor_HistoryDTo.Visit_Date;
            VistorHitory.VisitiorReason = Visitor_HistoryDTo.VisitiorReason;
            VistorHitory.Comment = Visitor_HistoryDTo.Comment;
            VistorHitory.ApplicationUserID = Visitor_HistoryDTo.ApplicationUserID;
            
            return cRUD_Repository.Insert(VistorHitory);
          
        }
        [HttpGet]
        public List<VistorHitory> getall()
        {
            return cRUD_Repository.Getall();
        }
    }
}
