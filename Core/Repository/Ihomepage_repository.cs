using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface Ihomepage_repository
    {
        public List<homepage> getall();

        public bool updatehomepage(homepage home);
    }
}
