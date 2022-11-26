using Core.Data;
using Core.DTO;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class message_snapchatservice : Imessage_snapchatservice
    {
        private readonly Imessage_snapchatrepository repo;
        public message_snapchatservice(Imessage_snapchatrepository repo)
        {
            this.repo = repo;
        }

        public List<chatDto> getallchat(int userid)
        {
            return repo.getallchat(userid);
        }

        public bool createmessage(message_snapchat message)
        {
            return repo.createmessage(message);
        }
        public bool deletemessagebyid(int id)
        {
            return repo.deletemessagebyid(id);
        }
        public bool deletemessagenotsaved()
        {
            return repo.deletemessagenotsaved();
        }

        public List<getmessage_dto> getmessage(int user1, int user2)
        {
            return repo.getmessage(user1, user2);
        }

        public List<chatDto> getmessagenotseen(int userid)
        {
            return repo.getmessagenotseen(userid);
        }


        public bool updatesave(int messageid, int messagesave)
        {
            return repo.updatesave(messageid, messagesave);
        }

        public bool updatestatus(int messageid, string messagestatus)
        {
            return repo.updatestatus(messageid, messagestatus);
        }
    }
}
