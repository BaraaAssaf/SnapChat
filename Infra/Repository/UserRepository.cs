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
    public class UserRepository  : IUserRepository
    {
        private readonly IDBContext DbContext;
        public UserRepository(IDBContext _DbContext)
        {
            DbContext = _DbContext;
        }

     

        public bool CreteUser(User user)
        {
            var p = new DynamicParameters();
            p.Add("@Ufirstname", user.firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Ulastname", user.lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uimagepath", user.imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uphone", user.phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uemail", user.email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Udateofbirth", user.dateofbirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Uaddress", user.address, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DbContext.dbConnection .ExecuteAsync("user_snapchat_package.CreteUser", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteUser(User user)
        {
            var p = new DynamicParameters();
            p.Add("@Uid",user.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.dbConnection.ExecuteAsync("user_snapchat_package.DeleteUser", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<User> GetAllUser()
        {

            IEnumerable<User> result = DbContext.dbConnection.Query<User>("user_snapchat_package.GetAllUser", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public List<User> GetUserById(int userid)
        {
            var p = new DynamicParameters();
            p.Add("@Uid", userid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<User> result = DbContext.dbConnection.Query<User>("user_snapchat_package.GetUserById", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<User> GetUserCount()
        {
            IEnumerable<User> result = DbContext.dbConnection.Query<User>("user_snapchat_package.GetAllUser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateUser(User user)
        {
            var p = new DynamicParameters();
            p.Add("@Uid", user.id, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Ufirstname", user.firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Ulastname", user.lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uimagepath", user.imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uphone", user.phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uemail", user.email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Udateofbirth", user.dateofbirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Uaddress", user.address, dbType: DbType.String, direction: ParameterDirection.Input);
            DbContext.dbConnection.ExecuteAsync("user_snapchat_package.UpdateUser", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
