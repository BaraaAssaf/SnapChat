using Core.Data;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace SnapChat.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {

        private readonly IAbout_Service about;

        public AboutUsController(IAbout_Service about)
        {
            this.about = about;

        }


        [HttpGet]
        public IActionResult getall()
        {
            try
            {
                return Ok(about.getall());
            }
            catch (Exception ex)
            {
                throw ex;
            }       
        }

        [HttpPost]
        [Route("uploadimage")]
        public aboutus uploaduserimage()
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
                aboutus item = new aboutus();
                item.imagePath = filename;
                return item;
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
   


        [HttpPut]
        public IActionResult update([FromBody] aboutus aboutus)
        {
            try
            {
                return Ok(about.updateabout(aboutus));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
 }

