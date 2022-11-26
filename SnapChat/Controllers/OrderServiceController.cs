using Core.Data;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SnapChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderServiceController : ControllerBase
    {

        private readonly IOrderService_service orderService_;
        public OrderServiceController(IOrderService_service orderService)
        {
            this.orderService_ = orderService;

        }


        [HttpPost]
        public IActionResult createorderservice([FromBody]orderservice_snapchat orderservice)
        {

            try
            {
                return Ok(orderService_.createorderservice(orderservice));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("gettotalsalesbyservice")]
        public IActionResult gettotalsalesbyservice()
        {
            try
            {
                return Ok(orderService_.gettotalsalesbyservice());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        

    } 
}

