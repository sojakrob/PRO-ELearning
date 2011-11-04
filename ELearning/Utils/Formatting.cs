using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace ELearning.Utils
{
    public class Formatting
    {
        public static string FormatAsDate(DateTime date)
        {
            return date.ToString("D", CultureInfo.CurrentUICulture);
        }
        public static string FormatAsTime(DateTime time)
        {
            return time.ToString("T", CultureInfo.CurrentUICulture);
        }
    }
}