using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface Itestimonial_repository
    {
        public List<testimonial> getalltestimonial();
        public List<testimonial> getalltestimonialadmin();

        public bool updatestatus(int id,int status);

        public bool createtestimonial(testimonial t);
    }
}
