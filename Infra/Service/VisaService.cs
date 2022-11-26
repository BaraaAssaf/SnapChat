using Core.Data;
using Core.Repository;
using Core.Service;
using Infra.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
   public  class VisaService : IVisaService
    {
            private readonly IVisaRepository visaRepository;
            public VisaService(IVisaRepository _visaRepository)
            {
               visaRepository = _visaRepository;
        }

        public bool CreateVisa(Visa_Snapchat visa_Snapchat)
        {
            return visaRepository.CreateVisa(visa_Snapchat);
        }

        public bool DeleteVisa(int id)
        {
            return visaRepository.DeleteVisa(id);
        }

        public List<Visa_Snapchat> GetAllVisa()
        {
            return visaRepository.GetAllVisa();
        }

        public bool UpdateVisa(Visa_Snapchat visa_Snapchat)
        {
            return visaRepository.UpdateVisa(visa_Snapchat);
        }
    }
}
