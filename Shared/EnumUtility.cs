using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ELearning.Shared
{
    public class EnumUtility
    {
        public static T EnumFromName<T>(string name)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), name);
            }
            catch (ArgumentException)
            {
                throw;
                return default(T);
                // TODO Log Unknown enumaration value
            }
        }
    }
}
