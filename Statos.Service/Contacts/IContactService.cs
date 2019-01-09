using System;
using System.Collections.Generic;
using Statos.Model.Contacts;

namespace Statos.Service.Contacts
{
    public interface IContactService
    {
        IEnumerable<ContactViewModel> GetAllContact();
        ContactViewModel GetContact(int contactId);
        void RemoveContact(int contactId);
        Contact CreateContact(ContactViewModel contactViewModel);

    }
}
