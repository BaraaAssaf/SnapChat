using Core.Domain;
using Core.DTO;
using Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace Infra.Repository
{
    public class createregister_repository : Icreateregister_repository
    {
        private readonly IDBContext DbContext;
        public createregister_repository(IDBContext _DbContext)
        {
            DbContext = _DbContext;
        }

        public bool createuser(register r)
        {
            var p = new DynamicParameters();
            p.Add("@Ufirstname", r.firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Ulastname", r.lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uimagepath", r.imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uphone", r.phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uemail", r.email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Udateofbirth", r.dateofbirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Uaddress", r.address, dbType: DbType.String, direction: ParameterDirection.Input);
            DbContext.dbConnection.ExecuteAsync("user_snapchat_package.CreteUser", p, commandType: CommandType.StoredProcedure);

            var par= new DynamicParameters();
            par.Add("ufirstname", r.firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            par.Add("ulastname", r.lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            par.Add("uemail", r.email, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<int> result = DbContext.dbConnection.Query<int>("user_snapchat_package.getuseridbyinfo",par, commandType: CommandType.StoredProcedure).ToList();
            string numb = result.FirstOrDefault().ToString();
            int n = Int32.Parse(numb);
            var p1 = new DynamicParameters();
            p1.Add("@Lusername", r.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p1.Add("@Lpassword", r.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p1.Add("@Lroleid", 100, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p1.Add("@Luserid", n, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p1.Add("@Lisactive", 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
             DbContext.dbConnection.ExecuteAsync("Login_snapchat_package.CreteLogin", p1, commandType: CommandType.StoredProcedure);
            
            return true;
        }




    }
}
