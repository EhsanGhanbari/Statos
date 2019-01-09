using System;
using System.ComponentModel.DataAnnotations;
using Statos.Globalization;

namespace Statos.Service.Blogs
{
    public class BlogViewModel
    {
        public int PostId { get; set; }

        [Required(ErrorMessageResourceType = typeof(EnglishContent), ErrorMessageResourceName = "TitleRequired")]
        public string Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(EnglishContent), ErrorMessageResourceName = "BodyRequired")]
        public string Body { get; set; }
        

        public string UrlSlug { get; set; }

        public DateTime CreationTime { get; set; }

        public string ShortTitle
        {
            get
            {
                if (Title.Length < 30)
                {
                    return Title;
                }
                return Title.Substring(0, 30);
            }
        }


        public string ShortBody
        {
            get
            {
                if (Body.Length < 200)
                {
                    return Body;
                }
                return Body.Substring(0, 600);
            }
        }
    }
}
