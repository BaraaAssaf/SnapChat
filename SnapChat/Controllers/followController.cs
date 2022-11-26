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
    public class followController : ControllerBase
    {
        private readonly Ifollow_snapchatservice fservice;
        public followController(Ifollow_snapchatservice fservice)
        {
            this.fservice = fservice;
        }

        [HttpPost]
        [Route("createfollow")]
        public ActionResult createfollow([FromBody] follow_snapchat follow) {
            return Ok(fservice.createfollow(follow));
        }

        [HttpPut]
        [Route("updatestatus/{fromu}/{tou}/{status}")]
        public ActionResult updatestatus(int fromu,int tou,int status)
        {
            return Ok(fservice.updatestatus(fromu,tou,status));
        }

        [HttpGet]
        [Route("getmyfriends/{uid}")]
        public ActionResult getmyfriends(int uid) {
            return Ok(fservice.getmyfriends(uid));
        }

        [HttpGet]
        [Route("getnoteficationFollow/{userid}")]
        public ActionResult getnoteficationFollow(int userid)
        {
            return Ok(fservice.getnoteficationFollow(userid));
        }

        [HttpGet]
        [Route("getfriendFollow/{userid}")]
        public ActionResult getfriendFollow(int userid)
        {
            return Ok(fservice.getfriendFollow(userid));
       
        }


        [HttpDelete]
        [Route("unfollow/{fromu}/{tou}")]
        public ActionResult unfollow(int fromu, int tou) {
            return Ok(fservice.unfollow(fromu, tou));
        }

    }
}
