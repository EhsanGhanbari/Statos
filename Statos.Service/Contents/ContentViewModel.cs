using System;

namespace Statos.Service.Contents
{
    public class ContentViewModel
    {
        public Guid ContentId { get; set; }
        public string AboutText { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }
        public long Mobile { get; set; }

        public string FaceBook { get; set; }
        public string GooglePlus { get; set; }
        public string Twitter { get; set; }

        public string ShortAboutText
        {
            get
            {
                if (AboutText.Length < 300)
                {
                    return AboutText;
                }
                return AboutText.Substring(0, 300);
            }
        }
    }
}
