using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Statos.Model.Languages;

namespace Statos.Service.Languages
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }


        /// <summary>
        /// Add a language to the system
        /// </summary>
        /// <param name="languageViewModel"></param>
        public void CreateLanguage(LanguageViewModel languageViewModel)
        {
            var language = languageViewModel.ConvertToLanguageModel();
            _languageRepository.Add(language);
            _languageRepository.SaveChanges();
        }


        /// <summary>
        /// Get the language by Identity
        /// </summary>
        /// <param name="languageId"></param>
        /// <returns></returns>
        public LanguageViewModel GetLanguage(int languageId)
        {
            var language = _languageRepository.FindBy(languageId);
            var languageViewMdoel = language.ConvertToLanguageViewModel();
            return languageViewMdoel;
        }


        /// <summary>
        /// Update the content of the language
        /// </summary>
        /// <param name="languageViewModel"></param>
        /// <returns></returns>
        public void UpdateLanguage(LanguageViewModel languageViewModel)
        {
            var language = languageViewModel.ConvertToLanguageModel();
            _languageRepository.Update(language);
            _languageRepository.SaveChanges();
        }

        /// <summary>
        /// Remove the language from the system
        /// </summary>
        /// <param name="languageId"></param>
        public void RemoveLanguage(int languageId)
        {
            var languageViewModel = new LanguageViewModel { LanguageId = languageId };
            var language = languageViewModel.ConvertToLanguageModel();
            _languageRepository.Delete(language);
            _languageRepository.SaveChanges();
        }


        /// <summary>
        /// Get all languages defined in the system
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LanguageViewModel> GetAllLanguages()
        {
            var language = _languageRepository.GetAll();
            var languageViewMdoel = language.ConvertToLanguageViewModelList();
            return languageViewMdoel;
        }

    }
}
