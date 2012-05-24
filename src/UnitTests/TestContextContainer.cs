using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitTests.Mocks;
using ELearning.Business.Managers;

namespace UnitTests
{
    class TestContextContainer
    {
        public TestStorage Storage { get; private set; }
        public TestIdentityProvider IdentityProvider { get; private set; }
        public ManagersContainer Container { get; private set; }


        /// <summary>
        /// Initializes a new instance of the TestContextContainer class.
        /// </summary>
        public TestContextContainer()
        {
            Storage = new TestStorage();
            IdentityProvider = new TestIdentityProvider(Storage);
            Container = new ManagersContainer(Storage, IdentityProvider);
        }
    }
}
