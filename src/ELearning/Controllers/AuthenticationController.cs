using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELearning.Models.Authentication;
using System.Web.Security;

namespace ELearning.Controllers
{
    public class AuthenticationController : BaseController
    {

        //
        // GET: /Authentication/

        public ActionResult Index()
        {
            return RedirectToAction("LogOn");
        }


        //
        // GET /Authentication/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST /Authentication/LogOn

        [HttpPost]
        public ActionResult LogOn(UserLogOnModel user)
        {
            if (ModelState.IsValid)
            {
                bool loginResult = AuthenticationContext.LogIn(user.Email, user.Password, user.KeepSignedIn);

                if (loginResult)
                    return RedirectToHome();
            }

            return View(user);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            AuthenticationContext.LogOff();

            return RedirectToHome();
        }


        public ActionResult LogOnControl()
        {
            return PartialView();
        }

        public ActionResult LoggedUserControl()
        {
            LoggedUserModel user;
            if (AuthenticationContext.IsUserLoggedIn)
                user = new LoggedUserModel() { Email = Membership.GetUser().Email };
            else
                user = null;

            return PartialView(user);
        }
    }
}
