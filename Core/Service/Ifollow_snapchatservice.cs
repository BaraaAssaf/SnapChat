using Core.Data;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface Ifollow_snapchatservice
    {
        public bool createfollow(follow_snapchat follow);
        public bool updatestatus(int fromuser, int touser, int followstatus);

        public List<getmyfriends> getmyfriends(int userid);

        public List<getmyfriends> getnoteficationFollow(int userid);
        public List<getmyfriends> getfriendFollow(int userid);
        public bool unfollow(int fromuser, int touser);
    }
}
