using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class SERVICE_service: ISERVICE_service
    {
        private readonly IService_Repository iservice;
        public SERVICE_service(IService_Repository service)
        {
            this.iservice = service;
        }


        public service_snapchat createservice(service_snapchat service)
        {
            return iservice.createservice(service);
        }
 

        public List<service_snapchat> getallservice()
        {
            return iservice.getallservice();
        }

        public bool deleteservice(int serviceid)
        {
            return iservice.deleteservice(serviceid);
        }


  

        public bool updateservice(service_snapchat service)
        {
            return iservice.updateservice(service);
        }
    }
}