using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ELearning.Business.Storages
{
    static class LocalStorage
    {
        public const string ROOT_PATH = "~/LocalStorage/";

        
        public static string GetExportPath(System.Web.HttpServerUtilityBase server)
        {
            return server.MapPath(string.Format("{0}Temporary/Export/", ROOT_PATH));
        }
    }
}
