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
    public class MsgContactusController : Controller
    {
        private readonly IMsgContactusService msgContactusService;
        public MsgContactusController(IMsgContactusService msgContactusService)
        {
            this.msgContactusService= msgContactusService;
        }
        [HttpPost]
        [ProducesResponseType(typeof(List<MsgContactus>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateMsgContactus([FromBody]MsgContactus msgContactus)
        {
            return msgContactusService.CreateMsgContactus(msgContactus);
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<MsgContactus>), StatusCodes.Status200OK)]

        public List<MsgContactus> GetAllMsgContactUs()
        {
            return msgContactusService.GetAllMsgContactUs();
        }
        [HttpDelete]
        [ProducesResponseType(typeof(MsgContactus), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete/{id}")]
        public bool DeleteMsgContactUs(int id)
        {
            return msgContactusService.DeleteMsgContactUs(id);
        }

    }
}
