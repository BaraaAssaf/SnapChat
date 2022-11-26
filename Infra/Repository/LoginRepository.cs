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
    public class LoginRepository : ILoginRepository
    {
        private readonly IDBContext DbContext;
        public LoginRepository(IDBContext _DbContext)
        {
            DbContext = _DbContext;
        }



        public bool CreteLogin(Login login)
        {
            var p = new DynamicParameters();
            p.Add("@Lusername", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Lpassword", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Lroleid", login.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Luserid", login.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Lisactive", login.Isactive, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.dbConnection.ExecuteAsync("Login_snapchat_package.CreteLogin", p, commandType: CommandType.StoredProcedure);
            return true;

        }


        public bool DeleteLogin(Login login)
        {
            var p = new DynamicParameters();
            p.Add("@Lid", login.ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.dbConnection.ExecuteAsync("teacher_package.Deletebook", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<getalluser_dto> GetAllActiveUser()
        {
            IEnumerable<getalluser_dto> result = DbContext.dbConnection.Query<getalluser_dto>("Login_snapchat_package.GetAllActiveUser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<getalluser_dto> GetAllUser()
        {
            IEnumerable<getalluser_dto> result = DbContext.dbConnection.Query<getalluser_dto>("Login_snapchat_package.GetallUser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }



        public bool UpdateIsActev(Login login)
        {
            var p = new DynamicParameters();
            p.Add("@Lid", login.ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Lisactive", login.Isactive, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.dbConnection.ExecuteAsync("Login_snapchat_package.UpdateIsActev", p, commandType: CommandType.StoredProcedure);
            return true;
        }


        public bool UpdateIsBlock(Login login)
        {
            var p = new DynamicParameters();
            p.Add("@Lid", login.ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Lisblock", login.Isblock, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.dbConnection.ExecuteAsync("Login_snapchat_package.UpdateIsBlock", p, commandType: CommandType.StoredProcedure);
            return true;
        }

     
        public bool UpdateLogenPassword(Login login)
        {
            var p = new DynamicParameters();
            p.Add("@Luserid", login.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Lpassword", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DbContext.dbConnection.ExecuteAsync("login_snapchat_package.UpdateLogenPassword", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public Login Auth(Login login)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("User_NAME", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("PASS", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Login> result = DbContext.dbConnection.Query<Login>
                 ("Login_snapchat_package.Auth", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
