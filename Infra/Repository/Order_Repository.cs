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
    public class Order_Repository : IOrder_Repository
    {
        private readonly IDBContext dBContext;

        public Order_Repository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public List<orderForEachService> countOfService()
        {
           
            IEnumerable<orderForEachService> result = dBContext.dbConnection.Query<orderForEachService>("order_Package.countOfService", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }


        public order_snapchat createorder(order_snapchat order)
        {
            var parameter = new DynamicParameters();
            var datenow = DateTime.Now;
            parameter.Add("tprice", order.totalprice, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("orderdate", datenow, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("uid", order.userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("sid", order.serviceid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync("order_Package.createorder", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return order;
        }

   
    }
}




