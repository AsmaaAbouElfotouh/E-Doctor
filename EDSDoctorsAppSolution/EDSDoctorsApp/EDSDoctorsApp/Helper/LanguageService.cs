using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using EDSDoctorsApp.Resources;
using Xamarin.Essentials;

namespace EDSDoctorsApp.Helper
{
    public class LanguageService
    {
        public static async Task SetLanguage(string lang)
        {
            var langculture = lang.ToLower() == "ar" ? "ar-EG" : lang.ToLower() == "en" ? "en-GB" : lang.ToLower() == "fr" ? "fr-FR" : lang.ToLower() == "sw" ? "sw-KE" : lang.ToLower() == "af" ? "af-ZA" : lang.ToLower();
            Preferences.Set("savedLang", lang);
            Preferences.Set("savedCulture", langculture);
            CultureInfo info = new CultureInfo(langculture);
            Thread.CurrentThread.CurrentCulture = info;
            Thread.CurrentThread.CurrentUICulture = info;
            DateTimeFormatInfo DateTimeFormat = info.DateTimeFormat;
            Thread.CurrentThread.CurrentCulture.DateTimeFormat = DateTimeFormat;
            AppResources.Culture = info;

        }
        public static string GetCulture { get => Thread.CurrentThread.CurrentCulture.Name; set { } }
    }
}
