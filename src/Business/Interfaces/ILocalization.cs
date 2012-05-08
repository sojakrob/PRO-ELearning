using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELearning.Business.Interfaces
{
    public interface ILocalization
    {
        string GetString(string key);
    }
}
