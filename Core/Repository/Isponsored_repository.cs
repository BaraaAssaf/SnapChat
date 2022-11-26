using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface Isponsored_repository
    {
        public bool createsponsored(sponsored spons);
        public List<sponsored> getallsponsored();
    }
}
