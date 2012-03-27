using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ELearning.Controllers
{
    public class SettingsController : BaseController
    {
        
        public ActionResult SetLanguage(string language, string url)
        {
            Language.SetCurrentLanguage(language);

            return Redirect(url);
        }
    }
}
