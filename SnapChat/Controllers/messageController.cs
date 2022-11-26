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
    public class messageController : ControllerBase
    {
        private readonly Imessage_snapchatservice mservice;
        public messageController(Imessage_snapchatservice mservice)
        {
            this.mservice = mservice;
        }


        [HttpPost]
        public ActionResult createmessage([FromBody] message_snapchat message) {
            return Ok(mservice.createmessage(message));
        }


        [HttpDelete]
        [Route("deletemessagebyid/{id}")]
        public ActionResult deletemessagebyid(int id)
        {
            return Ok(mservice.deletemessagebyid(id));
        }


        [HttpGet]
        [Route("getallchat/{userid}")]
        public ActionResult getallchat(int userid)
        {
            return Ok(mservice.getallchat(userid));
        }


        [HttpGet]
        [Route("getmessagenotseen/{userid}")]
        public ActionResult getmessagenotseen(int userid)
        {
            return Ok(mservice.getmessagenotseen(userid));
        }




        [HttpPut]
        [Route("updatesave/{mid}/{ms}")]
        public ActionResult updatesave(int mid,int ms) {
            return Ok(mservice.updatesave(mid, ms));
        }

        [HttpPut]
        [Route("updatestatus/{mid}/{ms}")]
        public ActionResult updatestatus(int mid, string ms)
        {
            return Ok(mservice.updatestatus(mid, ms));
        }

        [HttpGet]
        [Route("getmessage/{u1}/{u2}")]
        public ActionResult getmessage(int u1, int u2) {
            return Ok(mservice.getmessage(u1, u2));
        }

        [HttpDelete]
        [Route("deletemessagenotsaved")]
        public ActionResult deletemessagenotsaved()
        {
            return Ok(mservice.deletemessagenotsaved());
        }

        [HttpPost]
        [Route("sendattachment")]
        public message_snapchat uploadmessage()
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
                message_snapchat item = new message_snapchat();
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
