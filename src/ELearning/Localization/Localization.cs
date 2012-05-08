using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Business.Interfaces;

namespace ELearning
{
    public class Localization : ILocalization
	{
        public string GetString(string key)
        {
            return Localization.GetResourceString(key);
        }

        public static string GetResourceString(string key)
        {
            string result = Resources.Strings.ResourceManager.GetString(key);
            if (result == null)
                return string.Format("[{0}]", key);
            return result;
        }
	}
}