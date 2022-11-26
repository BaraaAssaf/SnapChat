using Core.Data;
using Core.DTO;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace SnapChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrder_service iorder;
        public OrderController(IOrder_service iorder)
        {
            this.iorder = iorder;

        }

        [HttpPost]
        public IActionResult createorder([FromBody]order_snapchat order)
        {
 
            try
            {
                return Ok(iorder.createorder(order));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<orderForEachService>), StatusCodes.Status200OK)]
        [Route("countOfService")]
        public List<orderForEachService> countOfService()
        {

            return iorder.countOfService();
        }

    }
}
