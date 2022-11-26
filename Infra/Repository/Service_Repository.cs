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
    public class Service_Repository : IService_Repository
    {
        private readonly IDBContext dBContext;

        public Service_Repository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
   
        public service_snapchat createservice(service_snapchat service)
        {

            var parameter = new DynamicParameters();

            parameter.Add("servicen", service.servicename, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("imgpath", service.imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("serviceprice", service.price, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dBContext.dbConnection.ExecuteAsync
                ("service_Package.createservice", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return service;
        }

        public bool deleteservice(int serviceid)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("@idservice ", serviceid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("service_package.deleteservice", parameter, commandType: CommandType.StoredProcedure);



            if (result == null)
                return false;
            return true;
        }


        public List<service_snapchat> getallservice()
        {



            IEnumerable<service_snapchat> result = dBContext.dbConnection.Query<service_snapchat>("service_Package.getallservice", commandType: CommandType.StoredProcedure);
            return result.ToList();


        }

        public bool updateservice(service_snapchat service)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                  ("idservice", service.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("servicen", service.servicename, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("imgpath", service.imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("serviceprice", service.price, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dBContext.dbConnection.ExecuteAsync
                ("service_Package.updateservice", parameter, commandType: CommandType.StoredProcedure);


            if (result == null)
                return false;
            return true;
        }
    }
}
