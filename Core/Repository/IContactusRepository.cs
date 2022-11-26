using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface IContactusRepository
    {
       public  List<ContactUs> GetAllContactUs();
        public bool UpdateContactUs(ContactUs contactUs);
       
    }
}
