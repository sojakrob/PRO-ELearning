using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELearning
{
	public class Localization
	{
        public static string GetResourceString(string key)
        {
            string result = Resources.Strings.ResourceManager.GetString(key);
            if (result == null)
                return string.Format("[{0}]", key);
            return result;
        }
	}
}