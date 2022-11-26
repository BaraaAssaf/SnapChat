using Core.Data;
using Core.Domain;
using Core.DTO;
using Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Infra.Repository
{
    public class OrderService_Repository : IOrderService_Repository
    {
        private readonly IDBContext dBContext;

        public OrderService_Repository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public orderservice_snapchat createorderservice(orderservice_snapchat orderservice)
        {
            var parameter = new DynamicParameters();

            parameter.Add("oid", orderservice.orderid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("sid", orderservice.serviceid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dBContext.dbConnection.ExecuteAsync
                ("orderservice_Package.createorderservice", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return orderservice;
        }

        public List<SalesDTO> gettotalsalesbyservice() 
        {
            IEnumerable<SalesDTO> result = dBContext.dbConnection.Query<SalesDTO>
                  ("orderservice_Package.gettotalsalesbyservice", commandType: System.Data.CommandType.StoredProcedure);

            return result.ToList();


        }

    }
}

