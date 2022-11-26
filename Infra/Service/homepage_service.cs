using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class homepage_service : Ihomepage_service
    {
        private readonly Ihomepage_repository repo;
        public homepage_service(Ihomepage_repository repo)
        {
            this.repo = repo;
        }

        public List<homepage> getall()
        {
            return repo.getall();
        }

        public bool updatehomepage(homepage home)
        {
            return repo.updatehomepage(home);
        }
    }
}
