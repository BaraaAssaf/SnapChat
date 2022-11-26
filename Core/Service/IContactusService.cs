using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IContactusService
    {
        public List<ContactUs> GetAllContactUs();
        public bool UpdateContactUs(ContactUs contactUs);
    }
}
