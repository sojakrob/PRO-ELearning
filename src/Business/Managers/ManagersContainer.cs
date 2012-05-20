using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Business.Storages;
using ELearning.Business.Permissions;

namespace ELearning.Business.Managers
{
    public class ManagersContainer
    {
        private IPersistentStorage _persistentStorage;
        private ELearning.Business.Interfaces.IIdentityProvider _permissionProvider;

        private Dictionary<Type, object> _managers = new Dictionary<Type, object>();


        public ManagersContainer(IPersistentStorage persistentStorage, ELearning.Business.Interfaces.IIdentityProvider permissionsProvider)
        {
            _persistentStorage = persistentStorage;
            _permissionProvider = permissionsProvider;
        }


        public T Get<T>() where T : class
        {
            if (!_managers.ContainsKey(typeof(T)))
            {
                var ctor = typeof(T).GetConstructor(new[] { typeof(IPersistentStorage), typeof(ManagersContainer), typeof(ELearning.Business.Interfaces.IIdentityProvider) });
                if (ctor == null)
                    throw new ApplicationException();
                Register((T)ctor.Invoke(new object[] { _persistentStorage, this, _permissionProvider }));
            }

            return (T)_managers[typeof(T)];
        }

        public void Register(object manager)
        {
            if (!_managers.ContainsKey(manager.GetType()))
                _managers.Add(manager.GetType(), manager);
            else
                _managers[manager.GetType()] = manager;
        }
    }
}
