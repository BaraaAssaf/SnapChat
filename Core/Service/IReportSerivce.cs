using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IReportSerivce
    {
        List<Report> getAllReport();
        bool CreateReport(Report report);
        bool updateReport(Report report);
        bool DeleteReport(Report report);


      
       
       
    }
}
