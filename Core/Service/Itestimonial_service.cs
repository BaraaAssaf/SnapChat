using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface Itestimonial_service
    {
        public List<testimonial> getalltestimonial();
        public List<testimonial> getalltestimonialadmin();

        public bool updatestatus(int id, int status);

        public bool createtestimonial(testimonial t);
    }
}
