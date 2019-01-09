using System;

namespace Statos.Model.Contents
{
    public class Content : IAggregateRoot
    {
        public int Id { get; set; }
        public string HeaderImage { get; set; }
        public string AboutText { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }
        public long Mobile { get; set; }
        public DateTime CreationTime { get; set; }

        public string FaceBook { get; set; }
        public string GooglePlus { get; set; }
        public string Twitter { get; set; }
    }
}
