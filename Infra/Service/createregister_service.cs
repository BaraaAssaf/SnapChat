using Core.DTO;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class createregister_service : Icreateregister_service
    {
        private readonly Icreateregister_repository repo;
        public createregister_service(Icreateregister_repository repo)
        {
            this.repo = repo;
        }

        public bool createuser(register r)
        {
            return repo.createuser(r);
        }
    }
}
