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
                // TODO LogOn
                if (Membership.ValidateUser(user.Email, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, user.KeepSignedIn);

                    return RedirectToAction("Index", "Home");
                }
            }

            return View(user);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            AuthenticationContext.LogOff();

            return RedirectToAction("Index", "Home");
        }
    }
}
