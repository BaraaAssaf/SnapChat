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
    public class testimonial_repository : Itestimonial_repository
    {
        private readonly IDBContext dbContext;
        public testimonial_repository(IDBContext dbContext)
        {

            this.dbContext = dbContext;
        }

        public bool createtestimonial(testimonial t)
        {
            var parameter = new DynamicParameters();
            parameter.Add("uid", t.userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("tmessage", t.message, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("tstatus", t.status, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("testimonial_Package.createtestimonial", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<testimonial> getalltestimonial()
        {
            var parameter = new DynamicParameters();

            IEnumerable<testimonial> result = dbContext.dbConnection.Query<testimonial>("testimonial_Package.getalltestimonial", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<testimonial> getalltestimonialadmin()
        {
            var parameter = new DynamicParameters();

            IEnumerable<testimonial> result = dbContext.dbConnection.Query<testimonial>("testimonial_Package.getalltestimonialadmin", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool updatestatus(int id, int status)
        {
            var parameter = new DynamicParameters();
            parameter.Add("tid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("tstatus", status, dbType: DbType.Int32, direction: ParameterDirection.Input);
            
            dbContext.dbConnection.ExecuteAsync("testimonial_Package.updatestatus", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
