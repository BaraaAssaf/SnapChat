using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IAbout_Service
    {
        public List<aboutus> getall();

        public bool updateabout(aboutus aboutus);
    }

}
