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
    public class message_snapchatrepository : Imessage_snapchatrepository
    {
        private readonly IDBContext dbContext;
        public message_snapchatrepository(IDBContext dbContext)
        {

            this.dbContext = dbContext;
        }

        public List<chatDto> getallchat(int userid)
        {
            var parameter = new DynamicParameters();
            parameter.Add("userid", userid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<chatDto> result = dbContext.dbConnection.Query<chatDto>("message_package.getallchatbyuser", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public List<chatDto> getmessagenotseen(int userid) 
        {
            var parameter = new DynamicParameters();
            parameter.Add("user", userid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<chatDto> result = dbContext.dbConnection.Query<chatDto>("message_package.getmessagenotseen", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }
        public bool deletemessagebyid(int id)
        {
            var parameter = new DynamicParameters();

            parameter.Add("idm", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.dbConnection.ExecuteAsync("message_package.deletemessagebyid", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool createmessage(message_snapchat message)
        {
            var parameter = new DynamicParameters();
            var datenow = DateTime.Now;
            parameter.Add("textmessage", message.text, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("pathmessage", message.path, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("mdate", datenow, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("statusmessage", message.status, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("saved",message.issave, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("sender", message.senderid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("reciever", message.receiverid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.dbConnection.ExecuteAsync("message_package.createmessage", parameter, commandType: CommandType.StoredProcedure);


            return true;

        }

        public bool deletemessagenotsaved()
        {
            dbContext.dbConnection.ExecuteAsync("message_package.deletemessagenotsaved", commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<getmessage_dto> getmessage(int user1, int user2)
        {
            var parameter = new DynamicParameters();
            parameter.Add("user1", user1, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("user2", user2, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<getmessage_dto> result = dbContext.dbConnection.Query<getmessage_dto>("message_package.getmessagebetweentwouser", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public bool updatesave(int messageid, int messagesave)
        {
            var parameter = new DynamicParameters();
            parameter.Add("messageid", messageid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("messagesave", messagesave, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.dbConnection.ExecuteAsync("message_package.updatesave", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }


        public bool updatestatus(int messageid, string messagestatus)
        {

            var parameter = new DynamicParameters();
            parameter.Add("messageid", messageid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("messagestatus", messagestatus, dbType: DbType.String, direction: ParameterDirection.Input);
            dbContext.dbConnection.ExecuteAsync("message_package.updatestatus", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
