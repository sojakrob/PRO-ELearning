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
using System.Web.Security;
using ELearning.Business.Exceptions;

namespace ELearning.Controllers
{
    public class BaseController : Controller
    {
        [Dependency]
        public IAuthenticationContext AuthenticationContext { get; set; }

        public BaseController()
        {
        }

        protected LoggedUserModel CurrentLoggedUserModel
        {
            get
            {
                if (!AuthenticationContext.IsUserLoggedIn)
                    return null;

                return new LoggedUserModel()
                            {
                                ID = AuthenticationContext.LoggedUserSession.User.ID,
                                Email = AuthenticationContext.LoggedUserSession.Email,
                                Type = AuthenticationContext.LoggedUserSession.Type,
                                Permissions = AuthenticationContext.LoggedUserSession.Permissions
                            };
            }
        }


        protected ICollection<Model> ModelsFromArray<Data, Model>(IEnumerable<Data> array, params object[] args)
            where Data : class
            where Model : DataModelBase<Data>
        {
            return DataModelBase<Data>.CreateFromArray<Model>(array, args);
        }


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            FillDefaultViewBag();

            base.OnActionExecuting(filterContext);
        }


        protected RedirectToRouteResult RedirectToHome()
        {
            return RedirectToAction("Index", "Home");
        }
        protected RedirectToRouteResult RedirectToLogOn()
        {
            return RedirectToAction("LogOn", "Authentication");
        }


        protected void FillDefaultViewBag()
        {
            ViewBag.CurrentUserModel = CurrentLoggedUserModel;
        }
    }
}
