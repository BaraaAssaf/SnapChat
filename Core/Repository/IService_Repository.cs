using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface IService_Repository
    {

        public List<service_snapchat> getallservice();
        public service_snapchat createservice(service_snapchat service);
        public bool deleteservice(int serviceid);
        public bool updateservice(service_snapchat service);
    }
}
