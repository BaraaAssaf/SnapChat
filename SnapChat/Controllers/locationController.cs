using Core.Data;
using Core.Domain;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SnapChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class locationController : ControllerBase
    {
        private readonly IDBContext dbContext;
        public locationController(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        public bool insertlocation([FromBody]location_snapchat location) {
            var parameter = new DynamicParameters();
          
            parameter.Add("uid", location.userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("latt", location.lat, dbType: DbType.Double, direction: ParameterDirection.Input);
            parameter.Add("lngg", location.lng, dbType: DbType.Double, direction: ParameterDirection.Input);
       
            dbContext.dbConnection.ExecuteAsync("location_Snapchat_package.createlocation", parameter, commandType: CommandType.StoredProcedure);
            return true;

        }
        [HttpDelete]
        [Route("deletelocation/{id}")]
        public bool deletelocation(int id) {
            var parameter = new DynamicParameters();
            parameter.Add("uid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.dbConnection.ExecuteAsync("location_Snapchat_package.deletelocation", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        [HttpGet]
       
        public List<location_snapchat> getlocation()
        
        {
            var parameter = new DynamicParameters();

            IEnumerable<location_snapchat> result = dbContext.dbConnection.Query<location_snapchat>("location_Snapchat_package.getalllocation", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

    }
}
