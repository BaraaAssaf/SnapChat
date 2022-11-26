using Core.Data;
using Core.DTO;
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
    public class LoginController : Controller
    {

        private readonly ILoginServce loginServce;

        public LoginController(ILoginServce _loginServce)
        {
            loginServce = _loginServce;
        }

        [HttpPost]
        [Route("AUTH")]
        public IActionResult Authen([FromBody] Login login)
        {
            var token = loginServce.Authentication_jwt(login);
            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }

        }

        [HttpGet]
        [ProducesResponseType(typeof(List<getalluser_dto>), StatusCodes.Status200OK)]
        [Route("getalluseractive")]
        public List<getalluser_dto> GetAllActiveUser()
        {

            return loginServce.GetAllActiveUser();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<getalluser_dto>), StatusCodes.Status200OK)]
        [Route("getalluser")]
        public List<getalluser_dto> GetAllUser()
        {

            return loginServce.GetAllUser();
        }

        [HttpPost]
        [ProducesResponseType(typeof(Login), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public bool CreteLogin([FromBody] Login login)
        {

            return loginServce.CreteLogin(login);

        }
        [HttpPut]
        [ProducesResponseType(typeof(Login), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("UpdateLogenPassword")]
        public bool UpdateLogenPassword([FromBody] Login login)
        {
            return loginServce.UpdateLogenPassword(login);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Login), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("UpdateIsActev")]
        public bool UpdateIsActev([FromBody] Login login)
        {
            return loginServce.UpdateIsActev(login);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Login), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("UpdateIsBlock")]
        public bool UpdateIsBlock([FromBody] Login login)
        {
            
            return loginServce.UpdateIsBlock(login);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Login), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete/{id}")]
        public bool DeleteLogin([FromBody] Login login)
        {


            return loginServce.DeleteLogin(login);
        }






        

    }
}
