using Statos.Model.Contacts;

namespace Statos.Repository.Contacts
{
    public class ContactRepository : Repository<Contact>,IContactRepository
    {
        public ContactRepository(StatosContext statosContext)
            : base(statosContext)
        {
        }
    }
}
