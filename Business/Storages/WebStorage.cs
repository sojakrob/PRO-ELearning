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


        private WebStorage()
        {
            if (HttpContext.Current == null)
                throw new SystemException("WebStorage can be used only in web environment");
        }


        #region IPersistentStorage Members

        public DataModelContainer GetDataContext()
        {
            DataModelContainer context = HttpContext.Current.Items[HTTPCONTEXT_DATA_MODEL_CONTAINER] as DataModelContainer;
            if (context == null)
            {
                context = new DataModelContainer();
                HttpContext.Current.Items.Add(HTTPCONTEXT_DATA_MODEL_CONTAINER, context);
            }

            return context;
        }

        #endregion
    }
}
