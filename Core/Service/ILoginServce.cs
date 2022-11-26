using Core.Data;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface ILoginServce
    {

        public string Authentication_jwt(Login login);
        List<getalluser_dto> GetAllActiveUser();
        List<getalluser_dto> GetAllUser();
        bool CreteLogin(Login login);
        bool UpdateLogenPassword(Login login);
        bool UpdateIsActev(Login login);
        bool UpdateIsBlock(Login login);
        bool DeleteLogin(Login login);

    }
}
