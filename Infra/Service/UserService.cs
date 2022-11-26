using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class UserService : IUserService
    {

        private readonly IUserRepository userRepository;

        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

      

        public bool CreteUser(User user)
        {
            return userRepository.CreteUser(user);
        }

        public bool DeleteUser(User user)
        {
            return userRepository.DeleteUser(user);
        }

        public List<User> GetAllUser()
        {
            return userRepository.GetAllUser();
        }

        public List<User> GetUserById(int userid)
        {
            return userRepository.GetUserById(userid);
        }

        public List<User> GetUserCount()
        {
            return userRepository.GetUserCount();
        }

        public bool UpdateUser(User user)
        {
            return userRepository.UpdateUser(user);
        }

      
    }
}
