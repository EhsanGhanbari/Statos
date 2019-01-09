using System;
using System.Web.Mvc;
using Statos.Service.Accounts;

namespace Statos.Web.UI.Areas.Manage.Controllers
{
    //[Authorize(Roles = "Administrator")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //if (MembershipService.ValidateUser(model.UserName, model.Password))
                //{
                //    SetupFormsAuthTicket(model.UserName, model.RememberMe);
                //    // -- Snip --
                //    return RedirectToAction("Index", "Home");
                //}
                //ModelState.AddModelError("","The user name or password provided is incorrect.");
            }

            return View();

        }



        /// <summary>
        /// Returns All Account of the System
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            var accounts = _accountService.GetAllAccounts();
            return View(accounts);
        }



        /// <summary>
        /// Manager can Create an Account as an Admin or Operator
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.GenderList = AccountViewModel.GetGender();
            ViewBag.RoleList = AccountViewModel.GetRole();
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(AccountViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                _accountService.CreateAccount(registerViewModel);
            }
            return View("Create");
        }


        /// <summary>
        /// returns the details of the account
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public ActionResult Datail(int accountId)
        {
            var account = _accountService.GetAccount(accountId);
            return View(account);
        }


        /// <summary>
        /// Remove Action will be call Via Ajax
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void Remove(int accountId)
        {
            if (ModelState.IsValid)
            {
                _accountService.RemoveAccount(accountId);
            }
        }

        /// <summary>
        /// Edit Action 
        /// Manager could Edit Every Account of a system
        /// Account Information Will be in PopUp View
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int accountId)
        {
            ViewBag.GenderList = AccountViewModel.GetGender();
            ViewBag.RoleList = AccountViewModel.GetRole();
            var account = _accountService.GetAccount(accountId);
            return View("Edit", account);
        }

        [HttpPost]
        public ActionResult Edit(AccountViewModel accountViewModel)
        {
            if (ModelState.IsValid)
            {
                _accountService.UpdateAccount(accountViewModel);
                return RedirectToAction("List");
            }
            return View("Edit");
        }


        /// <summary>
        /// ChangePassword Action, manager of the system can Reset the User Password
        /// </summary>
        /// <returns></returns>
        public ActionResult ResetPassword(int accountId)
        {
            var account = _accountService.GetAccount(accountId);
            return View(account);
        }

        [HttpPost]
        public ActionResult ResetPassword(AccountViewModel accountViewModel)
        {
            if (ModelState.IsValid)
            {
                _accountService.ResetPassword(accountViewModel);
            }
            return View();
        }
    }
}
