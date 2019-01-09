using System;
using System.Web.Mvc;
using Statos.Service.Contacts;

namespace Statos.Web.UI.Areas.Manage.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactUsService;

        public ContactController(IContactService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        /// <summary>
        /// List Of All Contacts
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
           var contact= _contactUsService.GetAllContact();
            return View("List",contact);
        }


        /// <summary>
        /// returns the contactdetails n PopUp 
        /// CRUD operation will be done in Pop Up
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public ActionResult Details(int contactId)
        {
            var contact = _contactUsService.GetContact(contactId);
            return View("Details",contact);
        }

     
       
        /// <summary>
        /// this action will be call in a pop Up View
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(int contactId)
        {
            if (ModelState.IsValid)
            {
                _contactUsService.RemoveContact(contactId);
                 RedirectToAction("List");
            }
            return Json("");
        }





        /// <summary>
        /// reply to contact
        /// this action shows a pop up modal to get the user Name and password
        /// </summary>
        /// <returns></returns>
        public ActionResult Reply(int contactId)
        {
            return View();
        }


        /// <summary>
        /// Reply to contact method 
        /// </summary>
        [HttpPost]
        public ActionResult Reply(ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
    }
}
