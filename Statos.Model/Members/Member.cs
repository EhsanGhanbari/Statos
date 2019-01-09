using System;

namespace Statos.Model.Members
{
    /// <summary>
    /// Define the Blog Members or News Letters Members
    /// </summary>
    public class Member : IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
