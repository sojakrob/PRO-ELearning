using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Business.Repositories;
using ELearning.Business.Storages;
using ELearning.Data;
using System.Linq.Expressions;

namespace ELearning.Business.Managers
{
    public abstract class ManagerBase<T> : IRepository<T> where T : class
    {
        private IPersistentStorage _persistentStorage;

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
        public ManagerBase(IPersistentStorage persistentStorage)
        {
            _persistentStorage = persistentStorage;
        }



        #region IRepository<T> Members

        public virtual IQueryable<T> GetAll()
        {
            return Context.CreateObjectSet<T>();
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return GetAll().SingleOrDefault<T>(predicate);
        }

        #endregion
    }
}
