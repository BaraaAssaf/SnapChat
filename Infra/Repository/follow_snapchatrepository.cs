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
    public class follow_snapchatrepository : Ifollow_snapchatrepository
    {
        private readonly IDBContext dbContext;
        public follow_snapchatrepository(IDBContext dbContext)
        {

            this.dbContext = dbContext;
        }
        public bool createfollow(follow_snapchat follow)
        {
            var parameter = new DynamicParameters();

            parameter.Add("fromu", follow.fromuser, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("tou", follow.touser, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("followstatus", follow.status, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.dbConnection.ExecuteAsync("follow_package.createfollow", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<getmyfriends> getmyfriends(int userid)
        {
            var parameter = new DynamicParameters();
            parameter.Add("userid", userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<getmyfriends> result = dbContext.dbConnection.Query<getmyfriends>("follow_package.getmyfriends", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<getmyfriends> getnoteficationFollow(int userid) 
        {
            var parameter = new DynamicParameters();
            parameter.Add("userid", userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<getmyfriends> result = dbContext.dbConnection.Query<getmyfriends>("follow_package.getnoteficationFollow", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public List<getmyfriends> getfriendFollow(int userid) 
        {
            var parameter = new DynamicParameters();
            parameter.Add("userid", userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<getmyfriends> result = dbContext.dbConnection.Query<getmyfriends>("follow_package.getfriendFollow", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public bool unfollow(int fromuser, int touser)
        {
            var parameter = new DynamicParameters();

            parameter.Add("fromu", fromuser, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("tou", touser, dbType: DbType.Int32, direction: ParameterDirection.Input);
        
            dbContext.dbConnection.ExecuteAsync("follow_package.deletefollow", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }



        public bool updatestatus(int fromuser, int touser, int followstatus)
        {
            var parameter = new DynamicParameters();

            parameter.Add("fromu", fromuser, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("tou", touser, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("followstatus", followstatus, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("follow_package.updatestatus", parameter, commandType: CommandType.StoredProcedure);

            if (followstatus == 1)
            {
                var p = new DynamicParameters();

                p.Add("fromu", touser, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("tou", fromuser, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("followstatus", 1, dbType: DbType.Int32, direction: ParameterDirection.Input);
                dbContext.dbConnection.ExecuteAsync("follow_package.createfollow", p, commandType: CommandType.StoredProcedure);
            }
            else if (followstatus == 0) {
                var pp = new DynamicParameters();

                pp.Add("fromu", fromuser, dbType: DbType.Int32, direction: ParameterDirection.Input);
                pp.Add("tou", touser, dbType: DbType.Int32, direction: ParameterDirection.Input);

                dbContext.dbConnection.ExecuteAsync("follow_package.deletefollow", pp, commandType: CommandType.StoredProcedure);
            }
            return true;
        }
    }
}
