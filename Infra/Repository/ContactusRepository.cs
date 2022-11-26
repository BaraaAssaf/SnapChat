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
    public class ContactusRepository : IContactusRepository
    {
        private readonly IDBContext DBContext;
        public ContactusRepository(IDBContext _DBContext)
        {
            DBContext = _DBContext;
        }
        public List<ContactUs> GetAllContactUs()
        {
            IEnumerable<ContactUs> Result = DBContext.dbConnection.Query<ContactUs>("Contactus_PACKAGE.getallContactus", commandType: CommandType.StoredProcedure);
            return Result.ToList();
        }

        public bool UpdateContactUs(ContactUs contactUs)
        {
            var p = new DynamicParameters();
            p.Add("@CId", contactUs.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Ctext1", contactUs.text1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Ctext2", contactUs.text2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Ctext3", contactUs.text3, dbType: DbType.String, direction: ParameterDirection.Input);

            var Result = DBContext.dbConnection.ExecuteAsync("ContactUs_Package.UPDATEContactus", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
