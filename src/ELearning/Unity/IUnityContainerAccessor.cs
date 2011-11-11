using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

namespace ELearning.Unity
{
    public interface IUnityContainerAccessor
    {
        IUnityContainer UnityContainer { get; }
    }
}