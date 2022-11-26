using Core.Data;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace SnapChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {

        private readonly ISERVICE_service iservice;
        public ServiceController(ISERVICE_service service)
        {
            this.iservice = service;

        }


        [HttpPost]
        public IActionResult createservice([FromBody]service_snapchat service)
        {

            try
            {
                return Ok(iservice.createservice(service));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      


        [HttpDelete("delete/{serviceid}")]
        public IActionResult deleteservice(int serviceid)
        {
            try
            {
                return Ok(iservice.deleteservice(serviceid));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        [HttpPost]
        [Route("uploadimage")]
        public service_snapchat uploadimage()
        {
            try
            {
                var file = Request.Form.Files[0];
                var filename = Guid.NewGuid().ToString() + "_" + file.FileName;
                var fullpath = Path.Combine("C:\\Users\\BARAA\\Desktop\\snapchat\\snapchat\\snapchat\\src\\assets\\img", filename);
                using (var stream = new FileStream(fullpath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                service_snapchat item = new service_snapchat();
                item.imagepath = filename;
                return item;
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<service_snapchat>), StatusCodes.Status200OK)]
        public List<service_snapchat> GetAllService()
        {

            return iservice.getallservice();
        }


        [HttpPut]
        public IActionResult updateservice([FromBody]service_snapchat service)
        {
            try
            {
                return Ok(iservice.updateservice(service));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

     
        
    }
}
