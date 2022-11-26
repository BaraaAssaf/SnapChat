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
    public class homepage_repository : Ihomepage_repository
    {
        private readonly IDBContext dbContext;
        public homepage_repository(IDBContext dbContext)
        {

            this.dbContext = dbContext;
        }
        public List<homepage> getall()
        {
            var parameter = new DynamicParameters();
            
            IEnumerable<homepage> result = dbContext.dbConnection.Query<homepage>("homepage_Package.getall", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool updatehomepage(homepage home)
        {
            var parameter = new DynamicParameters();
            parameter.Add("hid", home.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("htext1", home.text1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("htext2", home.text2, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("htext3", home.text3, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("imgpath", home.imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            dbContext.dbConnection.ExecuteAsync("homepage_Package.updatehomepage", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
