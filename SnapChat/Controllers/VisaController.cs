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
    public class VisaController : Controller
    {
        private readonly IVisaService visaService;
        private readonly IOrder_service order;
        public VisaController(IVisaService visaService, IOrder_service order)
        {
            this.visaService = visaService;
            this.order = order;
        }
        [HttpPost]
        [ProducesResponseType(typeof(List<Visa_Snapchat>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateVisa([FromBody] Visa_Snapchat visa_Snapchat)
        {
            return visaService.CreateVisa(visa_Snapchat);
        }

        [HttpPut]
        [ProducesResponseType(typeof(List<Visa_Snapchat>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateVisa([FromBody] Visa_Snapchat visa_Snapchat)
        {
            return visaService.UpdateVisa(visa_Snapchat);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Visa_Snapchat), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete/{id}")]
        public bool DeleteVisa(int id)
        {
            return visaService.DeleteVisa(id);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Visa_Snapchat>), StatusCodes.Status200OK)]

        public List<Visa_Snapchat> GetAllVisa()
        {
            return visaService.GetAllVisa();
        }

        [HttpGet]
        [Route("checkvisa/{price}/{SerialNumber}/{SecurityCode}/{ExpireDate}/{userid}/{serviceid}")]
        public bool checkvisa(int price , long SerialNumber , int SecurityCode , DateTime ExpireDate , int userid , int serviceid)  {
          List<Visa_Snapchat> v = visaService.GetAllVisa();
            order_snapchat o = new order_snapchat();
            var s = v.Where(x => x.SerialNumber == SerialNumber && x.SecurityCode == SecurityCode).FirstOrDefault();

            if (s == null)
                return false;//"visa not Valid";
            else
            {
                if (s.Balance >= price)
                {
                    s.Balance = s.Balance - price;
                    visaService.UpdateVisa(s);
                    o.serviceid = serviceid;
                    o.userid = userid;
                    o.totalprice = price;
                    order.createorder(o);
                    return true; //"Valid";
                }
                else return false;//"your balance is not enough";
            }
        }
    }
}
