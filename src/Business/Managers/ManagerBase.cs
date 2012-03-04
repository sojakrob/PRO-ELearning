using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Business.Repositories;
using ELearning.Business.Storages;
using ELearning.Data;
using System.Linq.Expressions;
using ELearning.Business.Permissions;

namespace ELearning.Business.Managers
{
    public abstract class ManagerBase<T> : IRepository<T> where T : class
    {
        protected IPersistentStorage _persistentStorage;

        protected UserPermissions Permissions { get; private set; }

        /// <summary>
        /// Gets current data context
        /// </summary>
        protected DataModelContainer Context
        {
            get { return _persistentStorage.GetDataContext(); }
        }


        /// <summary>
        /// Initializes a new instance of the ManagerBase class.
        /// </summary>
        /// <param name="persistentStorage"></param>
        [Obsolete]
        public ManagerBase(IPersistentStorage persistentStorage)
        {
            _persistentStorage = persistentStorage;
        }
        public ManagerBase(IPersistentStorage persistentStorage, IPermissionsProvider permissionsProvider)
        {
            _persistentStorage = persistentStorage;
            Permissions = permissionsProvider.GetPermissions();
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
