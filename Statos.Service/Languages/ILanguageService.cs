using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Statos.Model.Languages;

namespace Statos.Service.Languages
{
    public interface ILanguageService
    {
        void CreateLanguage(LanguageViewModel languageViewModel);
        LanguageViewModel GetLanguage(int languageId);
        void UpdateLanguage(LanguageViewModel languageViewModel);
        void RemoveLanguage(int languageId);
        IEnumerable<LanguageViewModel> GetAllLanguages();
    }
}
