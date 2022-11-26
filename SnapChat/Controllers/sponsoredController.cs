using Core.Data;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SnapChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sponsoredController : ControllerBase
    {
        private readonly Isponsored_service sservice;
        public sponsoredController(Isponsored_service sservice)
        {
            this.sservice = sservice;
        }

        [HttpGet]
        public ActionResult getallsponsored()
        {
            return Ok(sservice.getallsponsored());
        }

        [HttpPost]
        public ActionResult createsponsored([FromBody] sponsored spons)
        {
            return Ok(sservice.createsponsored(spons));
        }


        [HttpPost]
        [Route("uploadsponsor")]
        public sponsored uploadsponsor()
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
                sponsored item = new sponsored();
                item.path = filename;
                return item;
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
    }
}
