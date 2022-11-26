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
    [Route("api/[Controller]")]
    [ApiController]
    public class ContactusController : Controller
    {
        private readonly IContactusService contactusService;
        public ContactusController(IContactusService contactusService)
        {
            this.contactusService = contactusService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<ContactUs>), StatusCodes.Status200OK)]

        public List<ContactUs> GetAllContactUs()
        {
            return contactusService.GetAllContactUs();
        }
        [HttpPut]
        [ProducesResponseType(typeof(List<ContactUs>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateContactUs(ContactUs contactUs)
        {
            return contactusService.UpdateContactUs(contactUs);
        }

    }
}
