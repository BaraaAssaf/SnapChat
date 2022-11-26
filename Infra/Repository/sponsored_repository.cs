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
    public class sponsored_repository : Isponsored_repository
    {
        private readonly IDBContext dbContext;
        public sponsored_repository(IDBContext dbContext)
        {

            this.dbContext = dbContext;
        }
        public bool createsponsored(sponsored spons)
        {
            var parameter = new DynamicParameters();
            var datenow = DateTime.Now;
            parameter.Add("stitle", spons.title, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("stext", spons.text, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("spath", spons.path, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("sdate", datenow, dbType: DbType.String, direction: ParameterDirection.Input);
            dbContext.dbConnection.ExecuteAsync("sponsored_package.createsponsored", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<sponsored> getallsponsored()
        {
         

            IEnumerable<sponsored> result = dbContext.dbConnection.Query<sponsored>("sponsored_package.getallsponsored", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
