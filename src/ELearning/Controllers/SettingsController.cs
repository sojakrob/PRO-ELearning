using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELearning.Models.Settings;
using ELearning.Authentication;
using ELearning.Data.Enums;
using ELearning.Business.Managers;

namespace ELearning.Controllers
{
    public class SettingsController : BaseController
    {
        private UserManager _userManager;


        /// <summary>
        /// Initializes a new instance of the SettingsController class.
        /// </summary>
        public SettingsController(UserManager userManager)
        {
            _userManager = userManager;
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SetLanguage(string language, string url)
        {
            Language.SetCurrentLanguage(language);

            return Redirect(url);
        }

        [Authorize]        
        public ActionResult ChangePassword()
        {
            return View(new ChangePasswordModel());
        }
        [HttpPost]
        [Authorize]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid && model.NewPassword == model.NewPasswordAgain)
            {
                bool success = _userManager.ChangePassword(model.OldPassword, model.NewPassword);
                if (success)
                    return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
