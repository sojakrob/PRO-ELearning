using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Business.Repositories;
using ELearning.Business.Storages;
using ELearning.Data;

namespace ELearning.Business.Managers
{
    public abstract class ManagerBase<T> : Repository<T> where T : class
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
    }
}
