using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Statos.Model.Languages;

namespace Statos.Service.Languages
{
    public static class LanguageMapper
    {
        /// <summary>
        /// Convert to language view model
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public static LanguageViewModel ConvertToLanguageViewModel(this Language language)
        {
            return Mapper.Map<Language, LanguageViewModel>(language);
        }


        /// <summary>
        /// Convert to language model
        /// </summary>
        /// <param name="languageViewModel"></param>
        /// <returns></returns>
        public static Language ConvertToLanguageModel(this LanguageViewModel languageViewModel)
        {
            return Mapper.Map<LanguageViewModel, Language>(languageViewModel);
        }


        /// <summary>
        /// Convert To Language View Model list
        /// </summary>
        /// <param name="languages"></param>
        /// <returns></returns>
        public static IEnumerable<LanguageViewModel> ConvertToLanguageViewModelList(this IEnumerable<Language> languages)
        {
            return Mapper.Map<IEnumerable<Language>, IEnumerable<LanguageViewModel>>(languages);
        }

    }
}
