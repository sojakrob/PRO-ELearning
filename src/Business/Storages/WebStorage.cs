using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ELearning.Data;

namespace ELearning.Business.Storages
{
    public class WebStorage : IPersistentStorage
    {
        private const string HTTPCONTEXT_DATA_MODEL_CONTAINER = "DataModelContainer";
        private static readonly object _padlock = new object();


        /// <summary>
        /// Gets singleton instance
        /// </summary>
        public static WebStorage Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_padlock)
                    {
                        if (_instance == null)
                            _instance = new WebStorage();
                    }
                }

                return _instance;
            }
        }
        private static WebStorage _instance;


        private DataModelContainer DataModelContainer
        {
            get
            {
                return HttpContext.Current.Items[HTTPCONTEXT_DATA_MODEL_CONTAINER] as DataModelContainer;
            }
            set
            {
                if (HttpContext.Current.Items[HTTPCONTEXT_DATA_MODEL_CONTAINER] == null)
                    HttpContext.Current.Items.Add(HTTPCONTEXT_DATA_MODEL_CONTAINER, value);
                else
                    HttpContext.Current.Items[HTTPCONTEXT_DATA_MODEL_CONTAINER] = value;
            }
        }
        private bool IsDataModelContainerAssigned
        {
            get
            {
                return DataModelContainer != null;
            }
        }

        private string _connectionString;


        private WebStorage()
        {
            if (HttpContext.Current == null)
                throw new SystemException("WebStorage can be used only in web environment");
        }


        /// <summary>
        /// Changes the database of DataModelContainer
        /// </summary>
        /// <param name="connectionString">Connection string for the connection</param>
        public void ChangeDatabase(string connectionString)
        {
            if(_connectionString == connectionString)
                return; 

            _connectionString = connectionString;

            if(IsDataModelContainerAssigned)
                CreateDataModelContainer();
        }

        private void CreateDataModelContainer()
        {
            if (string.IsNullOrEmpty(_connectionString))
                DataModelContainer = new DataModelContainer();
            else
                DataModelContainer = new DataModelContainer(_connectionString);
        }

        #region IPersistentStorage Members

        public DataModelContainer GetDataContext()
        {
            if (!IsDataModelContainerAssigned)
                CreateDataModelContainer();

            return DataModelContainer;
        }

        #endregion
    }
}
