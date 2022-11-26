using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
   public interface IVisaService
    {
        bool CreateVisa(Visa_Snapchat visa_Snapchat);
        bool UpdateVisa(Visa_Snapchat visa_Snapchat);
        bool DeleteVisa(int id);
        List<Visa_Snapchat> GetAllVisa();
    }
}
