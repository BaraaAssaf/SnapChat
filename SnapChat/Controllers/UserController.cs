using Core.Data;
using Core.DTO;
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
    public class UserController : Controller
    {
        private readonly IUserService userService;

        private readonly Icreateregister_service uservice;
        public UserController(IUserService _userService, Icreateregister_service uservice)
        {
            this.userService = _userService;
            this.uservice = uservice;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        public List<User> GetAllUser()
        {

            return userService.GetAllUser();
        }

        //[HttpPost]
        //[ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]

        //public bool CreteUser([FromBody] User user)
        //{
        //    return userService.CreteUser(user);
        //}

        [HttpPost]
        public ActionResult createuser([FromBody] register r) {

            return Ok(uservice.createuser(r));

        }

        [HttpPut]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateUser([FromBody] User user)
        {
            return userService.UpdateUser(user);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete/{id}")]
        public bool DeleteUser([FromBody] User user)
        {


            return userService.DeleteUser( user);
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [Route("GetUserById/{userid}")]
        public List<User> GetUserById(int userid)
        {
            return userService.GetUserById(userid);
        }

        [HttpGet]
        [Route("GetUserCount")]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        public List<User> GetUserCount()
        {

            return userService.GetUserCount();
        }


        [HttpPost]
        [Route("uploaduserimage")]
        public register uploaduserimage()
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
                register item = new register();
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
