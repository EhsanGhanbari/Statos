using System;
using System.Web;
using System.Web.Mvc;
using Statos.Service.Contacts;
using Statos.Service.Contents;
using Statos.Service.Members;
using Statos.Web.UI.Helpers;

namespace Statos.Web.UI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IContactService _contactService;
        private readonly IContentService _contentService;
        private readonly IMemberService _memberService;


        public HomeController(IContactService contactService, IContentService contentService, IMemberService memberService)
        {
            _contactService = contactService;
            _contentService = contentService;
            _memberService = memberService;
        }

        /// <summary>
        /// Main Page of the Site
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Contact Us Action 
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            return View("Contact");
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel contactViewModel, string CaptchaValue, string InvisibleCaptchaValue)
        {
            bool cv = CaptchaController.IsValidCaptchaValue(CaptchaValue.ToUpper());
            bool icv = InvisibleCaptchaValue == "";

            if (!cv || !icv)
            {
                ModelState.AddModelError(string.Empty, "Captcha error.");
                return View();
            }

            if (ModelState.IsValid)
            {
                _contactService.CreateContact(contactViewModel);
                return View("ContactSuccess");
            }

            return View("Contact");
        }

        /// <summary>
        /// Redirect to Success page
        /// </summary>
        /// <returns></returns>
        public ActionResult ContactSuccess()
        {
            return View("ContactSuccess");
        }


        /// <summary>
        /// About Us ViewResult 
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            var about = _contentService.GetLatestContent();
            return View("About", about);
        }


        /// <summary>
        /// Returns a Part of About Us in View
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public PartialViewResult AboutSideBar()
        {
            var about = _contentService.GetLatestContent();
            return PartialView("AboutSideBar", about);
        }


        /// <summary>
        /// returns the Social NetWork
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public PartialViewResult SocialNetWorkSideBar()
        {
            var social = _contentService.GetLatestContent();
            return PartialView("SocialNetWorkSideBar", social);
        }



        /// <summary>
        /// Mamber Side bar to have newsletter in Email!
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public PartialViewResult MemberSideBar()
        {
            return PartialView("MemberSideBar");
        }


        /// <summary>
        /// Return 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Member(MemberViewModel memberViewModel)
        {
            if (ModelState.IsValid)
            {
                _memberService.CreateMember(memberViewModel);
            }
            return View("Index");
        }


        /// <summary>
        /// Develoeprs 
        /// </summary>
        /// <returns></returns>
        public ViewResult Developers()
        {
            return View();
        }



        /// <summary>
        /// Culture helper
        /// </summary>
        /// <param name="culture"></param>
        /// <returns></returns>
        public ActionResult SetCulture(string culture)
        {
            // Validate input
            culture = CultureHelper.GetValidCulture(culture);

            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {

                cookie = new HttpCookie("_culture");
                cookie.HttpOnly = false; // Not accessible by JS.
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);

            return RedirectToAction("Index");
        }
    }
}
