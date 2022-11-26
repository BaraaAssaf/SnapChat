using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IMsgContactusService
    {
        List<MsgContactus> GetAllMsgContactUs();
        public bool CreateMsgContactus(MsgContactus msgContactus);
        bool DeleteMsgContactUs(int id);
    }
}
