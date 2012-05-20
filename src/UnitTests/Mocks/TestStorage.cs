using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Business.Storages;
using ELearning.Data;

namespace UnitTests.Mocks
{
    internal class TestStorage : IPersistentStorage
    {
        private const string CONNECTION_STRING = "metadata=res://*/DataModel.csdl|res://*/DataModel.ssdl|res://*/DataModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;Data Source=MBPC\\SQLEXPRESS;Initial Catalog=ELearning_UnitTests;Integrated Security=True;MultipleActiveResultSets=True&quot;";

        private DataModelContainer _container;


        /// <summary>
        /// Initializes a new instance of the TestStorage class.
        /// </summary>
        public TestStorage()
        {
            _container = new DataModelContainer(CONNECTION_STRING);
        }


        #region IPersistentStorage Members

        public ELearning.Data.DataModelContainer GetDataContext()
        {
            return _container;
        }

        #endregion
    }
}
