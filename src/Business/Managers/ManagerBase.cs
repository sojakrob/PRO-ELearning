using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ELearning.Business.Storages;
using ELearning.Data;
using System.Linq.Expressions;
using ELearning.Business.Permissions;
using ELearning.Business.Exceptions;

namespace ELearning.Business.Managers
{
    public abstract class ManagerBase<T> : ELearning.Business.Interfaces.IRepository<T> where T : class
    {
        protected const int DEFAULT_ID = 0;


        protected IPersistentStorage _persistentStorage;

        protected ManagersContainer _managers;

        protected ELearning.Business.Interfaces.IIdentityProvider IdentityProvider { get; private set; }
        protected UserPermissions Permissions { get { return IdentityProvider.GetPermissions(); } }


        /// <summary>
        /// Gets current data context
        /// </summary>
        protected DataModelContainer Context
        {
            get { return _persistentStorage.GetDataContext(); }
        }


        public ManagerBase(
            IPersistentStorage persistentStorage,
            ManagersContainer container,
            ELearning.Business.Interfaces.IIdentityProvider permissionsProvider
            )
        {
            _persistentStorage = persistentStorage;

            _managers = container;
            _managers.Register(this);

            IdentityProvider = permissionsProvider;
        }


        protected void KickAnonymous()
        {
            if (IdentityProvider.User == null)
                throw new PermissionException("Access", "Not logged users cannot access specified page");
        }


        #region IRepository<T> Members

        public virtual IQueryable<T> GetAll()
        {
            return Context.CreateObjectSet<T>();
            // TODO Apply rights based on current user type
        }

        public virtual T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return GetAll().SingleOrDefault<T>(predicate);
        }

        #endregion
    }
}
