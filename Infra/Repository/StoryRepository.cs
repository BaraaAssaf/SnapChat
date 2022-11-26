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

    public class StoryRepository : IStoryRepository
    {
        private readonly IDBContext DBContext;


        public StoryRepository(IDBContext _DBContext)
        {
            DBContext = _DBContext;
        }

        public bool CreateStory(Story_Snapchat story_Snapchat)
        {
           
            var datenow = DateTime.Now;

            var p = new DynamicParameters();
            p.Add("suserid", story_Snapchat.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@spath", story_Snapchat.Path, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@sstartdate", datenow, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@sisblock", story_Snapchat.IsBlock, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var Result = DBContext.dbConnection.ExecuteAsync("Story_Package.CreateStory", p, commandType: CommandType.StoredProcedure);
            return true;
        }



        public bool DeleteStory(int id)
        {
            var p = new DynamicParameters();
            p.Add("@StoryId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var Result = DBContext.dbConnection.ExecuteAsync("Story_Package.DeleteStory", p, commandType: CommandType.StoredProcedure);
            return true;
        }



        public List<Story_Snapchat> Get24hour()
        {
            IEnumerable<Story_Snapchat> Result = DBContext.dbConnection.Query<Story_Snapchat>("Story_Package.Get24hour", commandType: CommandType.StoredProcedure);
            return Result.ToList();
        }



        public List<Story_Snapchat> GetAllStory()
        {
            IEnumerable<Story_Snapchat> Result = DBContext.dbConnection.Query<Story_Snapchat>("Story_Package.GetallStory", commandType: CommandType.StoredProcedure);
            return Result.ToList();
        }



        public List<Story_Snapchat> GetTop10()
        {
            IEnumerable<Story_Snapchat> Result = DBContext.dbConnection.Query<Story_Snapchat>("Story_Package.GetTop10", commandType: CommandType.StoredProcedure);
            return Result.ToList();
        }


        public bool Updateisblock(Story_Snapchat story_Snapchat)
        {
            var p = new DynamicParameters();
            p.Add("storyId", story_Snapchat.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@sisblock", story_Snapchat.IsBlock, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var Result = DBContext.dbConnection.ExecuteAsync("Story_Package.Updateisblock", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    
    }
}
