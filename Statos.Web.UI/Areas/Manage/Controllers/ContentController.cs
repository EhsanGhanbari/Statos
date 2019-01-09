using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Statos.Service.Contents;

namespace Statos.Web.UI.Areas.Manage.Controllers
{
    public class ContentController : Controller
    {
        private readonly IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }


        /// <summary>
        /// Create the content for the content
        /// about, social network
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ContentViewModel contentViewModel)
        {
            if (ModelState.IsValid)
            {
                _contentService.CreateContent(contentViewModel);
            }
            return View();
        }

        /// <summary>
        /// Edit the content of the content
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit()
        {
            var content = _contentService.GetLatestContent();
            return View(content);
        }
       
        [HttpPost]
        public ActionResult Edit(ContentViewModel contentViewModel)
        {
            if (ModelState.IsValid)
            {
                _contentService.CreateContent(contentViewModel);
            }
            return View();
        }



    }
}
