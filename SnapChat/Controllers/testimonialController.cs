using Core.Data;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnapChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testimonialController : ControllerBase
    {
        private readonly Itestimonial_service tservice;
        public testimonialController(Itestimonial_service tservice)
        {
            this.tservice = tservice;
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult getalltestimonial() {
            return Ok(tservice.getalltestimonial());
        }

        [HttpGet]
        [Route("getalltestimonialadmin")]
        public ActionResult getalltestimonialadmin()
        {
            return Ok(tservice.getalltestimonialadmin());
        }

        [HttpPut]
        [Route("updatestatus/{id}/{status}")]
        public ActionResult updatestatus(int id,int status)
        {
            return Ok(tservice.updatestatus(id,status));
        }
        [HttpPost]
        public ActionResult createtestimonial([FromBody] testimonial t)
        {
            return Ok(tservice.createtestimonial(t));
        }

    }
}
