using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IUserService
    {
       
        List<User> GetAllUser();
        bool CreteUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        List<User> GetUserCount();
        List<User> GetUserById(int userid);




       
    }
}
