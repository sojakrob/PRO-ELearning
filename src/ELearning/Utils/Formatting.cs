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


        public static string CropText(string text, int maxLength)
        {
            if (text != null && text.Length > maxLength)
                return String.Format("{0}...", text.Substring(0, maxLength));
            else
                return text;
        }
    }
}