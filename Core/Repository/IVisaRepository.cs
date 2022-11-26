using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface IVisaRepository
    {
       
        bool CreateVisa(Visa_Snapchat visa_Snapchat);
        bool UpdateVisa(Visa_Snapchat visa_Snapchat);
        bool DeleteVisa(int id);
        List<Visa_Snapchat> GetAllVisa();

    }
}
