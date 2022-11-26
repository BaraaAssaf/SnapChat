using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface IUserRepository
    {
      
        List<User> GetAllUser();
        bool CreteUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        List<User> GetUserCount();
        List<User> GetUserById(int userid);
    }
}
