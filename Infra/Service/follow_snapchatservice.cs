using Core.Data;
using Core.DTO;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class follow_snapchatservice : Ifollow_snapchatservice
    {
        private readonly Ifollow_snapchatrepository repo;
        public follow_snapchatservice(Ifollow_snapchatrepository repo)
        {
            this.repo = repo;
        }

        public bool createfollow(follow_snapchat follow)
        {
            return repo.createfollow(follow);
        }

        public List<getmyfriends> getmyfriends(int userid)
        {
            return repo.getmyfriends(userid);
        }

        public List<getmyfriends> getnoteficationFollow(int userid)
        {
            return repo.getnoteficationFollow(userid);
        }


        public List<getmyfriends> getfriendFollow(int userid)
        {
            return repo.getfriendFollow(userid);
        }


        public bool unfollow(int fromuser, int touser)
        {
            return repo.unfollow(fromuser, touser);
        }

     
        public bool updatestatus(int fromuser, int touser, int followstatus)
        {
            return repo.updatestatus(fromuser, touser, followstatus);
        }
    }
}
