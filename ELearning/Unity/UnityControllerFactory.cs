using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace ELearning.Unity
{
    public class UnityControllerFactory : DefaultControllerFactory
    {
        protected IUnityContainer _unityContainer;


        public UnityControllerFactory()
        {
            
        }
        public UnityControllerFactory(IControllerActivator controllerActivator)
            : base(controllerActivator)
        {
            
        }

        public override IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            IUnityContainerAccessor accessor = requestContext.HttpContext.ApplicationInstance as IUnityContainerAccessor;
            _unityContainer = accessor.UnityContainer;

            return base.CreateController(requestContext, controllerName);
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return null;

            return _unityContainer.Resolve(controllerType) as IController;
        }
    }
}