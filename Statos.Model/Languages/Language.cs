using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statos.Model.Languages
{
    public class Language : IAggregateRoot
    {
        public int Id { get; set; }
        public string Translation { get; set; }
    }
}
