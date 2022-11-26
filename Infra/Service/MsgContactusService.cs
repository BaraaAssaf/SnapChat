using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class MsgContactusService : IMsgContactusService
    {
        private readonly IMsgContactusRepository msgContactusRepository ;
        public MsgContactusService(IMsgContactusRepository _msgContactusRepository)
        {
            msgContactusRepository =_msgContactusRepository;
        }

        public bool CreateMsgContactus(MsgContactus msgContactus)
        {
            return msgContactusRepository.CreateMsgContactus(msgContactus);
        }

        public bool DeleteMsgContactUs(int id)
        {
            return msgContactusRepository.DeleteMsgContactUs(id);
        }

        public List<MsgContactus> GetAllMsgContactUs()
        {
            return msgContactusRepository.GetAllMsgContactUs();
        }
    }
}
