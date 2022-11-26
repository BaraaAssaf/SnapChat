using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface Ihomepage_service
    {
        public List<homepage> getall();

        public bool updatehomepage(homepage home);
    }
}
