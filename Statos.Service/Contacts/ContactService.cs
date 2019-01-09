using System;
using System.Collections.Generic;
using System.Linq;
using Statos.Model.Contacts;

namespace Statos.Service.Contacts
{
    public class ContactService : IContactService
    {

        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;

        }


        /// <summary>
        /// Create contact ,actually message sending by every website visitor 
        /// </summary>
        /// <param name="contactViewModel"></param>
        /// <returns></returns>
        public Contact CreateContact(ContactViewModel contactViewModel)
        {
            var contact = contactViewModel.ConvertToContactModel();
            contact.CreationTime = DateTime.Now;
            _contactRepository.Add(contact);
            _contactRepository.SaveChanges();
            return contact;
        }


        /// <summary>
        /// returns All Contact of system
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ContactViewModel> GetAllContact()
        {
            var contact = _contactRepository.GetAll().OrderByDescending(b => b.CreationTime);
            var contactUsViewModel = contact.ConvertToContactViewModelList();
            return contactUsViewModel;
        }

        /// <summary>
        /// Find contact by Id
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public ContactViewModel GetContact(int contactId)
        {
            var contact = _contactRepository.FindBy(contactId);
            var selectedContact = contact.ConvertToContactViewModel();
            return selectedContact;

        }

        /// <summary>
        /// remove made contact from DB
        /// </summary>
        /// <param name="contactId"></param>
        public void RemoveContact(int contactId)
        {
            var contact = new Contact { Id = contactId };
            _contactRepository.Delete(contact);
            _contactRepository.SaveChanges();
        }



    }
}
