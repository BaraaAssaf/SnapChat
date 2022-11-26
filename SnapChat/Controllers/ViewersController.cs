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
    public class ViewersController : Controller
    {
        private readonly IViewersService viewersService;
        public ViewersController(IViewersService viewersService)
        {
            this.viewersService =viewersService;
        }
        [HttpPost]
        [ProducesResponseType(typeof(List<Story_Snapchat>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateViewers([FromBody]Viewers_Snapchat viewers_Snapchat)
        {
            return viewersService.CreateViewers(viewers_Snapchat);
        }
        [HttpPost]
        [ProducesResponseType(typeof(List<CountViewersDTO>), StatusCodes.Status200OK)]
        [Route("CountViewers")]
        public List<CountViewersDTO> CountViewers([FromBody]InputViewersDTO inputViewersDTO)
        {
            return viewersService.CountViewers(inputViewersDTO);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Viewers_Snapchat>), StatusCodes.Status200OK)]
        [Route("getallViewers/{id}")]
        public List<Viewers_Snapchat> getallViewers(int id)
        {
            return viewersService.getallViewers(id);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CountTop10>), StatusCodes.Status200OK)]
        [Route("getcounttop10")]
        public List<CountTop10> getcounttop10()
        {
            return viewersService.getcounttop10();
        }
    }
}
