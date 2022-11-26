using Core.Data;
using Core.Domain;
using Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Infra.Repository
{
    public class ReportRepository :IReportRepository
    {
        private readonly IDBContext DbContext;
        public ReportRepository(IDBContext _DbContext)
        {
            DbContext = _DbContext;
        }

        public bool CreateReport(Report report)
        {
            var p = new DynamicParameters();
            var d = DateTime.Now;
            p.Add("@Rmessage", report.message, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Rreportfrom", report.reportfrom, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Rreportto", report.reportto, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Rreportdate", d, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = DbContext.dbConnection.ExecuteAsync("report_snapchat_package.CreateReport", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteReport(Report report)
        {
            var p = new DynamicParameters();
            p.Add("@Lid", report.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.dbConnection.ExecuteAsync("report_snapchat_package.DeleteReport", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Report> getAllReport()
        {
            IEnumerable<Report> result = DbContext.dbConnection.Query<Report>("report_snapchat_package.getAllReport", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool updateReport(Report report)
        {
            var p = new DynamicParameters();
            p.Add("@Rid", report.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Rstatus", report.status, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.dbConnection.ExecuteAsync("report_snapchat_package.updateReport", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
