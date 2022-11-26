using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface AboutUs_Repository
    {
        public List<aboutus> getall();

        public bool updateAbout(aboutus aboutus);

    }
}

