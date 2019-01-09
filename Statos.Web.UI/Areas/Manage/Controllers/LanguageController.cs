using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Statos.Service.Languages;

namespace Statos.Web.UI.Areas.Manage.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }


        /// <summary>
        /// list of All langues supported by the system
        /// </summary>
        /// <returns></returns>
        public ViewResult List()
        {
            var languages = _languageService.GetAllLanguages();
            return View(languages);
        }

        /// <summary>
        /// Add a language to the system 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(LanguageViewModel languageViewModel)
        {
            if (ModelState.IsValid)
            {
                _languageService.CreateLanguage(languageViewModel);
            }
            return View();
        }


        /// <summary>
        ///Removes a language from the system
        /// </summary>
        /// <returns></returns>
        public void Delete(int languageId)
        {
            _languageService.RemoveLanguage(languageId);
        }



        /// <summary>
        /// Edit the content of the languages
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int languageId)
        {
            var language = _languageService.GetLanguage(languageId);
            return View(language);
        }


        [HttpPost]
        public ActionResult Edit(LanguageViewModel languageViewModel)
        {
            if (ModelState.IsValid)
            {
                _languageService.UpdateLanguage(languageViewModel);
            }
            return View();
        }
    }
}
