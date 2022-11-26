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
    public class AboutUs_Repo : AboutUs_Repository
    {

        private readonly IDBContext dBContext;

        public AboutUs_Repo(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }



        public List<aboutus> getall()
        {      
           IEnumerable<aboutus> result = dBContext.dbConnection.Query<aboutus>
                ("AboutUs_Package.GetAll", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool updateAbout(aboutus aboutus)
        {
            var parameter = new DynamicParameters();
            parameter.Add ("AId", aboutus.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("AName", aboutus.name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("image", aboutus.imagePath, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("txt", aboutus.text, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dBContext.dbConnection.ExecuteAsync
                        ("AboutUs_Package.UpdateAbout", parameter, commandType: CommandType.StoredProcedure);


            if (result == null)
                return false;
            return true;
        }

      
    }
}











