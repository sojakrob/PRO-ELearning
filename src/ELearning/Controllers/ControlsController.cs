using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELearning.Models.Authentication;
using System.Web.Security;

namespace ELearning.Controllers
{
    public class ControlsController : BaseController
    {
        //
        // GET: /Controls/HeaderControl

        public ActionResult HeaderControl()
        {
            return PartialView();
        }

        //
        // GET: /Controls/MainMenuControl

        public ActionResult MainMenuControl()
        {
            return PartialView(CurrentLoggedUserModel);
        }
    }
}
