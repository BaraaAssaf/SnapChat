using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
   public interface Isponsored_service
    {
        public bool createsponsored(sponsored spons);
        public List<sponsored> getallsponsored();
    }
}
