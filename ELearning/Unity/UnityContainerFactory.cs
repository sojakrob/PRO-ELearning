using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using ELearning.Business.Storages;
using ELearning.Business.Managers;

namespace ELearning.Unity
{
    public class UnityContainerFactory
    {
        /// <summary>
        /// Initializes a new instance of the UnityContainerBuilder class.
        /// </summary>
        private UnityContainerFactory()
        {
        }


        public static IUnityContainer CreateContainer()
        {
            UnityContainer result = new UnityContainer();

            InjectionConstructor storage = new InjectionConstructor(WebStorage.Instance);

            result.RegisterType<FormManager>(storage);

            return result;
        }
    }
}