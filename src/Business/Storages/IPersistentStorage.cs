using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Data;

namespace ELearning.Business.Storages
{
    public interface IPersistentStorage
    {
        DataModelContainer GetDataContext();
    }
}
