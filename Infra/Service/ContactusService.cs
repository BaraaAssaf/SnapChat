using Core.Data;
using Core.Repository;
using Core.Service;
using Infra.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class ContactusService : IContactusService
    {
        private readonly IContactusRepository contactusRepository;
        public ContactusService(IContactusRepository _contactusRepository)
        {
            contactusRepository =_contactusRepository;
        }

        public List<ContactUs> GetAllContactUs()
        {
            return contactusRepository.GetAllContactUs();
        }

        public bool UpdateContactUs(ContactUs contactUs)
        {
            return contactusRepository.UpdateContactUs(contactUs);
        }

        
    }
}
