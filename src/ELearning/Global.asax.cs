﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ELearning.Unity;
using Microsoft.Practices.Unity;

namespace ELearning
{
    public class MvcApplication : System.Web.HttpApplication, IUnityContainerAccessor
    {
        /// <summary>
        /// Gets the Unity container of the current application
        /// </summary>
        public static IUnityContainer UnityContainer
        {
            get { return _unityContainer; }
        }
        private static IUnityContainer _unityContainer;


        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            InitUnity();
        }
        protected void Application_End(object sender, EventArgs e)
        {
            CleanUp();
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            Language.ChangeLanguageIfSet();
        }

        private static void InitUnity()
        {
            var unityContainerFactory = new UnityContainerFactory();
            _unityContainer = unityContainerFactory.CreateContainer();

            ControllerBuilder.Current.SetControllerFactory(typeof(UnityControllerFactory));
        }

        private static void CleanUp()
        {
            if (_unityContainer != null)
                _unityContainer.Dispose();
        }



        #region IUnityContainerAccessor Members

        /// <summary>
        /// Gets the Unity container of the application
        /// </summary>
        IUnityContainer IUnityContainerAccessor.UnityContainer
        {
            get { return _unityContainer; }
        }

        #endregion
    }
}