using Core.Data;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface Imessage_snapchatservice
    {
        public bool createmessage(message_snapchat message);

        public bool updatesave(int messageid, int messagesave);
        public bool deletemessagebyid(int id);
        public bool updatestatus(int messageid, string messagestatus);

        public List<getmessage_dto> getmessage(int user1, int user2);

        public List<chatDto> getmessagenotseen(int userid);

        public List<chatDto> getallchat(int userid);

        public bool deletemessagenotsaved();
    }
}
