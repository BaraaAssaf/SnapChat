using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class sponsored_service:Isponsored_service
    {

        private readonly Isponsored_repository repo;
        public sponsored_service(Isponsored_repository repo)
        {
            this.repo = repo;
        }

        public bool createsponsored(sponsored spons)
        {
            return repo.createsponsored(spons);
        }

        public List<sponsored> getallsponsored()
        {
            return repo.getallsponsored();
        }
    }
}
