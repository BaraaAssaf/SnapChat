using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class About_Service : IAbout_Service
    {
        private readonly AboutUs_Repository about;
        public About_Service(AboutUs_Repository about)
        {
            this.about = about;
        }

        public List<aboutus> getall()
        {
            return about.getall();  
        }

        public bool updateabout(aboutus aboutus)
        {
            return about.updateAbout(aboutus);
        }
    }
}


