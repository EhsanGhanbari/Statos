using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Statos.Web.UI.Controllers
{
    public class ErrorController : Controller
    {

        /// <summary>
        /// Not Found Page
        /// </summary>
        /// <returns></returns>
        public ActionResult NotFound()
        {
            return View();
        }


    }
}
