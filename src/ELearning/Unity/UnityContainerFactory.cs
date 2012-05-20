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
using ELearning.Business.Permissions;

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
            ELearning.Business.Interfaces.IIdentityProvider permissionProvider = new WebAuthenticationContext();

            ManagersContainer managersContainer = new ManagersContainer(storage, permissionProvider);
            var globalManagerConstructor = new InjectionConstructor(storage, managersContainer, new AnonymousPermissionsProvider());
            var managerConstructor = new InjectionConstructor(storage, managersContainer, permissionProvider);

            result.RegisterType<UserManager>("Global", globalManagerConstructor);
            result.RegisterType<UserManager>(managerConstructor);
            result.RegisterType<FormManager>(managerConstructor);
            result.RegisterType<QuestionManager>(managerConstructor);
            result.RegisterType<GroupManager>(managerConstructor);
            result.RegisterType<TextBookManager>(managerConstructor);

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