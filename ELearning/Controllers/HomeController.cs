using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ELearning.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (AuthenticationContext.IsUserLoggedIn)
                return RedirectToAction("Home");

            return View();
        }

        //
        // GET: /Home/Home

        public ActionResult Home()
        {
            if (!AuthenticationContext.IsUserLoggedIn)
                return RedirectToLogOn();

            return View();
        }
    }
}
