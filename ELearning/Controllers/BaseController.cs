using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELearning.Models.Data;
using ELearning.Business.Storages;
using ELearning.Authentication;
using Microsoft.Practices.Unity;
using ELearning.Models.Authentication;

namespace ELearning.Controllers
{
    public class BaseController : Controller
    {
        [Dependency]
        public IAuthenticationContext AuthenticationContext { get; set; }

        protected LoggedUserModel CurrentLoggedUserModel
        {
            get
            {
                return new LoggedUserModel()
                            {
                                Email = AuthenticationContext.LoggedUserSession.Email,
                                Type = AuthenticationContext.LoggedUserSession.Type
                            };
            }
        }


        protected ICollection<Model> ModelsFromArray<Data, Model>(IEnumerable<Data> array)
            where Data : class
            where Model : DataModelBase<Data>
        {
            return DataModelBase<Data>.CreateFromArray<Model>(array);
        }


        protected RedirectToRouteResult RedirectToHome()
        {
            return RedirectToAction("Index", "Home");
        }
        protected RedirectToRouteResult RedirectToLogOn()
        {
            return RedirectToAction("LogOn", "Authentication");
        }
    }
}
