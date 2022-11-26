using Core.Data;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
   public interface Imessage_snapchatrepository
    {
        public bool createmessage(message_snapchat message);

        public bool updatesave(int messageid,int messagesave );

        public bool updatestatus(int messageid, string messagestatus);

        public bool deletemessagebyid(int id);

        public List<chatDto> getallchat(int userid);

        public List<chatDto> getmessagenotseen(int userid);
        public List<getmessage_dto> getmessage(int user1, int user2);
        public bool deletemessagenotsaved();
    }
}
