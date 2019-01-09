using System.Collections.Generic;
using AutoMapper;
using Statos.Model.Contacts;

namespace Statos.Service.Contacts
{
    public static class ContactMapper
    {
        /// <summary>
        /// Convert To ContactViewModel
        /// </summary>
        /// <param name="contactUs"></param>
        /// <returns></returns>
        public static ContactViewModel ConvertToContactViewModel(this Contact contactUs)
        {
            Mapper.CreateMap<Contact, ContactViewModel>()
                  .ForMember(con => con.ContactId, src => src.MapFrom(c => c.Id));
            return Mapper.Map<Contact, ContactViewModel>(contactUs);
        }

        /// <summary>
        /// Convert To ContactModel
        /// </summary>
        /// <param name="contactUsViewModel"></param>
        /// <returns></returns>
        public static Contact ConvertToContactModel(this ContactViewModel contactUsViewModel)
        {
            return Mapper.Map<ContactViewModel, Contact>(contactUsViewModel);
        }

        /// <summary>
        /// Convert To Contact ViewModelList
        /// </summary>
        /// <param name="contacts"></param>
        /// <returns></returns>
        public static IEnumerable<ContactViewModel> ConvertToContactViewModelList(this IEnumerable<Contact> contacts)
        {
            Mapper.CreateMap<Contact, ContactViewModel>()
                .ForMember(con => con.ContactId, src => src.MapFrom(c => c.Id));
            return Mapper.Map<IEnumerable<Contact>, IEnumerable<ContactViewModel>>(contacts);
        }
    }
}
