using System;
using System.ComponentModel.DataAnnotations;
using Statos.Globalization;

namespace Statos.Service.Contacts
{
    public class ContactViewModel
    {

        public int ContactId { get; set; }


        public string Name { get; set; }


        [Required(ErrorMessageResourceType = typeof(EnglishContent),
             ErrorMessageResourceName = "EmailRequired")]
        [RegularExpression(".+@.+\\..+", ErrorMessageResourceType = typeof(EnglishContent),
            ErrorMessageResourceName = "EmailInvalid")]  
        public string Email { get; set; }


        public string Title { get; set; }


         [Required(ErrorMessageResourceType = typeof(EnglishContent),
             ErrorMessageResourceName = "BodyRequired")]
        public string Body { get; set; }



        public DateTime CreationTime { get; set; }


        public string ReplyMessage { get; set; }

    }
}
