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
    public class VisaRepository : IVisaRepository
    {
        private readonly IDBContext DBContext;
        public VisaRepository(IDBContext _DBContext)
        {
            DBContext = _DBContext;
        }
        public bool CreateVisa(Visa_Snapchat visa_Snapchat)
        {
            var p = new DynamicParameters();
            p.Add("@Vsecuritycode", visa_Snapchat.SecurityCode, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Vexpiredate", visa_Snapchat.ExpireDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Vbalance", visa_Snapchat.Balance, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("@Vserialnumber", visa_Snapchat.SerialNumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var Result = DBContext.dbConnection.ExecuteAsync("Visa_Package.CreateVisa", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteVisa(int id)
        {
            var p = new DynamicParameters();
            p.Add("@VId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var Result =DBContext.dbConnection.ExecuteAsync("Visa_Package.DeleteVisa", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Visa_Snapchat> GetAllVisa()
        {
            IEnumerable<Visa_Snapchat> Result = DBContext.dbConnection.Query<Visa_Snapchat>("Visa_Package.GetallVisa", commandType: CommandType.StoredProcedure);

            return Result.ToList();
        }

        public bool UpdateVisa(Visa_Snapchat visa_Snapchat)
        {
            var p = new DynamicParameters();
            p.Add("@VId", visa_Snapchat.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Vbalance", visa_Snapchat.Balance, dbType: DbType.Double, direction: ParameterDirection.Input);
            
            var Result = DBContext.dbConnection.ExecuteAsync("Visa_Package.UpdateVisa", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
    }
