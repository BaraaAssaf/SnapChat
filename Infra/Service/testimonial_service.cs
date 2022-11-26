using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class testimonial_service : Itestimonial_service
    {
        private readonly Itestimonial_repository repo;
        public testimonial_service(Itestimonial_repository repo)
        {
            this.repo = repo;
        }

        public bool createtestimonial(testimonial t)
        {
            return repo.createtestimonial(t);
        }

        public List<testimonial> getalltestimonial()
        {
            return repo.getalltestimonial();
        }

        public List<testimonial> getalltestimonialadmin()
        {
            return repo.getalltestimonialadmin();
        }

        public bool updatestatus(int id, int status)
        {
            return repo.updatestatus(id, status);
        }
    }
}
