using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using ELearning.Business.Storages;
using ELearning.Business.Managers;
using System.Configuration;
using System.Collections;
using ELearning.Authentication;
using ELearning.Controllers;

namespace ELearning.Unity
{
    public class UnityContainerFactory
    {
        /// <summary>
        /// Initializes a new instance of the UnityContainerBuilder class.
        /// </summary>
        public UnityContainerFactory()
        {
        }


        public virtual IUnityContainer CreateContainer()
        {
            UnityContainer result = new UnityContainer();

            IPersistentStorage storage = InitStorage();
            InjectionConstructor storageConstructor = new InjectionConstructor(storage);

            result.RegisterType<UserManager>(storageConstructor);
            result.RegisterType<FormManager>(storageConstructor);
            result.RegisterType<QuestionManager>(storageConstructor);

            result.RegisterType<IAuthenticationContext, WebAuthenticationContext>();

            return result;
        }


        protected virtual IPersistentStorage InitStorage()
        {
            string connectionStringName = ConfigurationManager.AppSettings["ConnectionStringName"];
            if (connectionStringName == null)
                throw new ApplicationException("Cannot find ConnectionStringName in AppSettings");

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[connectionStringName];
            if (settings == null)
                throw new ApplicationException("Cannot find specified connection string in ConnectionStrings");

            string connectionString = settings.ConnectionString;
            WebStorage.Instance.ChangeDatabase(connectionString);

            return WebStorage.Instance;
        }
    }
}