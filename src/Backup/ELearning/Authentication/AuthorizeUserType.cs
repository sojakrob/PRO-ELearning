using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELearning.Data.Enums;
using ELearning.Business.Exceptions;
using System.Web.Security;

namespace ELearning.Authentication
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple=false, Inherited=true)]
    public class AuthorizeUserType : AuthorizeAttribute
    {
        public UserTypes UserType { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.User == null || !httpContext.User.Identity.IsAuthenticated)
                throw new PermissionException("Access");

            var user = Membership.GetUser(httpContext.User.Identity.Name) as ELearningMembershipUser;

            if (user.Type == UserTypes.Administrator)
                return true;

            if (user.Type == UserTypes.Lector)
            {
                if (UserType == UserTypes.Lector || UserType == UserTypes.Student)
                    return true;
                else
                    throw new PermissionException("Access");
            }

            if (user.Type == UserTypes.Student)
            {
                if(UserType == UserTypes.Student)
                    return true;
                else
                    throw new PermissionException("Access");
            }

            return base.AuthorizeCore(httpContext);
        }
    }
}