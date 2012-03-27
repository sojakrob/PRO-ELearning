using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Globalization;

namespace ELearning
{
    public class Language
    {
        private const string LANGUAGE = "language";


        public static void ChangeLanguageIfSet()
        {
            if (System.Web.HttpContext.Current.Session == null)
                return;

            string language = System.Web.HttpContext.Current.Session[LANGUAGE] as string;
            if (string.IsNullOrEmpty(language))
                return;

            string localeID = GetLocaleId(language);

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(localeID);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(localeID);
        }
        public static void SetCurrentLanguage(string language)
        {
            System.Web.HttpContext.Current.Session[LANGUAGE] = language;

            ChangeLanguageIfSet();
        }
        public static string GetLocaleId(string language)
        {
            string localeID = "en-GB";
            switch (language)
            {
                case "cs":
                    localeID = "cs-CZ";
                    break;
            }
            return localeID;
        }
    }
}