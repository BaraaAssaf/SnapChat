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
    public class homepageController : ControllerBase
    {
        private readonly Ihomepage_service hservice;
        public homepageController(Ihomepage_service hservice)
        {
            this.hservice = hservice;
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult getall() {
            return Ok(hservice.getall());
        }
        [HttpPut]
        [Route("updatehomepage")]
        public ActionResult updatehomepage([FromBody]homepage home){
            return Ok(hservice.updatehomepage(home));
        }

        [HttpPost]
        [Route("uploadhomeimage")]
        public homepage uploadhomeimage()
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
                homepage item = new homepage();
                item.imagepath = filename;
                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
