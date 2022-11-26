using Core.Data;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public  interface ILoginRepository
    {
        List<getalluser_dto> GetAllActiveUser();

        List<getalluser_dto> GetAllUser();
        public Login Auth(Login login);

        bool CreteLogin(Login login);
        
        bool UpdateLogenPassword(Login login);
        bool UpdateIsActev(Login login);
        bool UpdateIsBlock(Login login);
        bool DeleteLogin(Login login);

    }
}
