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
    public class ReportController : Controller
    {
        private readonly IReportSerivce reportSerivce;

        public ReportController(IReportSerivce _rourseService)
        {

            reportSerivce = _rourseService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Report>), StatusCodes.Status200OK)]
        public List<Report> getAllReport()
        {

            return reportSerivce.getAllReport();
        }

        [HttpPost]
        [ProducesResponseType(typeof(Report), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public bool CreateReport([FromBody] Report report)
        {
            return reportSerivce.CreateReport(report);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Report), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool updateReport([FromBody] Report report)
        {
            return reportSerivce.updateReport(report);
        }
        [HttpDelete]
        [ProducesResponseType(typeof(Report), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public bool DeleteReport([FromBody] Report report)
        {


            return reportSerivce.DeleteReport(report);
        }

       

    }
}
