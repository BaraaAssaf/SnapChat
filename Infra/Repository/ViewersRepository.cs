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
    public class ViewersRepository : IViewersRepository
    {
        private readonly IDBContext DBContext;
        public ViewersRepository(IDBContext _DBContext)
        {
            DBContext = _DBContext;
        }
        public List<CountViewersDTO> CountViewers(InputViewersDTO inputViewersDTO)
        {
            var p = new DynamicParameters();
            p.Add("@vstoryid", inputViewersDTO.vstoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
           
            IEnumerable<CountViewersDTO> Result = DBContext.dbConnection.Query<CountViewersDTO>("Viewers_Package.CountViewers", p, commandType: CommandType.StoredProcedure);
            return Result.ToList();
        }

        
         public bool CreateViewers(Viewers_Snapchat viewers_Snapchat)
         {

            IEnumerable<Viewers_Snapchat> Result1 = DBContext.dbConnection.Query<Viewers_Snapchat>("Viewers_Package.GetallViewers", commandType: CommandType.StoredProcedure);
            var v = Result1.Where(x => x.StoryId == viewers_Snapchat.StoryId && x.ViewersId == viewers_Snapchat.ViewersId).FirstOrDefault();
            if (v == null)
            {
                var p = new DynamicParameters();
                p.Add("@vstoryid", viewers_Snapchat.StoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@vviewersid", viewers_Snapchat.ViewersId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var Result = DBContext.dbConnection.ExecuteAsync("Viewers_Package.CreateViewers", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            return false;
         }

        public List<Viewers_Snapchat> getallViewers(int id)
        {

            IEnumerable<Viewers_Snapchat> Result = DBContext.dbConnection.Query<Viewers_Snapchat>("Viewers_Package.GetallViewers", commandType: CommandType.StoredProcedure);
            var v = Result.Where(x => x.StoryId == id).ToList();


            return v.ToList();
        }

        public List<CountTop10> getcounttop10() 
        {
            IEnumerable<CountTop10> Result = DBContext.dbConnection.Query<CountTop10>
                ("Story_Package.getcountveiwers", commandType: CommandType.StoredProcedure);


            return Result.ToList();
        }

    }

}
