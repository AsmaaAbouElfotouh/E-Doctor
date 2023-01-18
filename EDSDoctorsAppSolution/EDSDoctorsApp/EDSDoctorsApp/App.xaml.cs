using EDSDoctorsApp.APIs.HR;
using EDSDoctorsApp.APIs.Account;
using EDSDoctorsApp.Helper.EMR;
using EDSDoctorsApp.Models;
using EDSDoctorsApp.Pages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EDSDoctorsApp
{
    public interface ILocalize //MUST BE OUTSIDE APP CLASS
    {
        CultureInfo GetCurrentCultureInfo();
        void SetLocale(CultureInfo ci);
    }
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        readonly CultureInfo ci = null;
        const string ResourceId = "EDSDoctorsApp.Resources.AppResources";

        static readonly Lazy<ResourceManager> ResMgr = new Lazy<ResourceManager>(
            () => new ResourceManager(ResourceId, IntrospectionExtensions.GetTypeInfo(typeof(TranslateExtension)).Assembly));

        public string Text { get; set; }

        public TranslateExtension()
        {
            try
            {
                ci = new CultureInfo(Preferences.Get("savedLang", "en"));
            }
            catch
            {
                ci = new CultureInfo("en");
            }
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return string.Empty;

            var translation = ResMgr.Value.GetString(Text, ci);
            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    string.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, ci.Name),
                    "Text");
#else
                translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
        }
    }

    class PrefixValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                string s = value.ToString();
                int prefixLength;
                if (!int.TryParse(parameter.ToString(), out prefixLength) ||
                    s.Length <= prefixLength)
                {
                    return s;
                }
                if (s.Contains(" "))
                    return s.Split(' ')[0].Substring(0, prefixLength).ToUpper() + " " + s.Split(' ')[1].Substring(0, prefixLength).ToUpper();
                else
                    return s.Substring(0, prefixLength).ToUpper();
            }
            catch
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
    public partial class App : Application
    {
        public static string DB_PATH = string.Empty;
        public static string PatientID = string.Empty;
        public static List<string> SelectedImages = new List<string>();
        public static int BookingPage = 1;
        public static int BookingPage2 = 1;
        public static int PatientsPage = 1;

        public static string LoadMoreBookingsRequest1 = "";
        public static string LoadMoreBookingsRequest2 = "";
        public static string LoadMorePatientsRequest = "";

        public static double TotalBookingsPages1 = 0;
        public static double TotalBookingsPages2 = 0;
        public static double TotalPages = 0;

        public static PatientVM PatientEMR;
        public static APIs.HR.StaffModel DoctorProfile = new APIs.HR.StaffModel();
        public static APIs.Account.StaffModel StaffProfile = new APIs.Account.StaffModel();

        public App()
        {
            InitializeComponent();
            string fileName = "LocalDB.sqlite";
            string fileLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);
            DB_PATH = fileLocation;
            init();
        }

        public async void init()
        {
            var Lang = Preferences.Get("savedLang", "en");
            await Helper.LanguageService.SetLanguage(Lang);
            Xamarin.Essentials.Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
            Xamarin.Essentials.Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

            if (!string.IsNullOrEmpty(await SecureStorage.GetAsync("credEncrypted")))
            {
                UserLogin userLogin = new UserLogin();
                userLogin.credEncrypted = await SecureStorage.GetAsync("credEncrypted");

                ////Call Login Backend API to validate user credentials
                var Result = Shared.PostAPI($"api/Authenticate/en-GB/Authenticate/login/true", JsonConvert.SerializeObject(userLogin), true);
                if (!string.IsNullOrEmpty(Result))
                {
                    await SecureStorage.SetAsync("credEncrypted", JObject.Parse(Result)["result"]["credEncrypted"].ToString());
                    await SecureStorage.SetAsync("userToken", JObject.Parse(Result)["result"]["token"].ToString());
                    await SecureStorage.SetAsync("userRefreshToken", JObject.Parse(Result)["result"]["refreshToken"].ToString());
                    MainPage = new NavigationPage(new HomePage());
                }
                else
                {
                    if (Device.RuntimePlatform == "iOS")
                        MainPage = new NavigationPage(new LoginPage_iOS());
                    else
                        MainPage = new NavigationPage(new LoginPage());
                }
            }
            else
            {
                if (Device.RuntimePlatform == "iOS")
                    MainPage = new NavigationPage(new LoginPage_iOS());
                else
                    MainPage = new NavigationPage(new LoginPage());
            }
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess == NetworkAccess.Internet)
            {
                //if (Preferences.Get("SyncProfile", false))
                //Shared.DoSync();
            }
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        public static void Refresh_Page(params object[] args)
        {
            var page = App.Current.MainPage.Navigation.NavigationStack.Last().GetType();
            Application.Current.MainPage.Navigation.InsertPageBefore((ContentPage)Activator.CreateInstance(page, args), App.Current.MainPage.Navigation.NavigationStack.Last());
            Application.Current.MainPage.Navigation.PopAsync();
        }

        public static string Between(string STR, string FirstString, string LastString)
        {
            string FinalString = "";
            try
            {
                int Pos1 = STR.IndexOf(FirstString) + FirstString.Length;
                int Pos2 = STR.IndexOf(LastString);
                FinalString = STR.Substring(Pos1, Pos2 - Pos1);
            }
            catch
            { }
            return FinalString;
        }
        public class FBuserdata
        {
            public string user_Id { get; set; }
            public string user_Token { get; set; }
            public string user_Email { get; set; }
        }
        public FBuserdata fbUser { get; set; }

    }
}
//$"api/Authenticate/{Preferences.Get("savedCulture","en-GB")}/Authenticate/login/false"