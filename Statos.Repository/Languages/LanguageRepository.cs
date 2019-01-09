using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Statos.Model.Languages;

namespace Statos.Repository.Languages
{
    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        public LanguageRepository(StatosContext statosContext)
            : base(statosContext)
        {
        }
    }
}
