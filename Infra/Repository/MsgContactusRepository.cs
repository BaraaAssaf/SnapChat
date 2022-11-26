using Core.Data;
using Core.Domain;
using Core.Repository;
using Dapper;
using Infra.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Infra.Repository
{
    public class MsgContactusRepository : IMsgContactusRepository
    {
        private readonly IDBContext DBContext;
        public MsgContactusRepository(IDBContext _DBContext)
        {
            DBContext = _DBContext;
        }
        public bool CreateMsgContactus(MsgContactus msgContactus)
        {
            var p = new DynamicParameters();
            p.Add("@Cname", msgContactus.name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Cemail", msgContactus.email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Csubject", msgContactus.subject, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Cmessage", msgContactus.message, dbType: DbType.String, direction: ParameterDirection.Input);

            var Result = DBContext.dbConnection.ExecuteAsync("MsgContactUs_Package.CREATEMsgContactus", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteMsgContactUs(int id)
        {
            var p = new DynamicParameters();
            p.Add("@CId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var Result = DBContext.dbConnection.ExecuteAsync("MsgContactus_package.DeleteMsgContactUs", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<MsgContactus> GetAllMsgContactUs()
        {
            IEnumerable<MsgContactus > Result = DBContext.dbConnection.Query<MsgContactus>("MsgContactus_package.GetAllMsgContactUs", commandType: CommandType.StoredProcedure);
            
            return Result.ToList();
        }
    }
}
