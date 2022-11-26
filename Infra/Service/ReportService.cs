using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class ReportService : IReportSerivce
    {
        private readonly IReportRepository reportRepository;

        public ReportService(IReportRepository _reportRepository)
        {
            reportRepository = _reportRepository;
        }

        public bool CreateReport(Report report)
        {
            return reportRepository.CreateReport(report);
        }

        public bool DeleteReport(Report report)
        {
            return reportRepository.DeleteReport(report);
        }

        public List<Report> getAllReport()
        {
            return reportRepository.getAllReport();
        }

        public bool updateReport(Report report)
        {
            return reportRepository.updateReport(report);
        }
    }
}
