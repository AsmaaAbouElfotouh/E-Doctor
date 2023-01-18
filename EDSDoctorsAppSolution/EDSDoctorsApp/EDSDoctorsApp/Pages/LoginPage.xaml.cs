using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using EDSDoctorsApp.HtmlViews;
using EDSDoctorsApp.Helper;
using EDSDoctorsApp.HtmlViews;
using EDSDoctorsApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EDSDoctorsApp.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Set_Language();
        }

        async void Set_Language()
        {
            var Lang = Preferences.Get("savedLang", "en");
            await LanguageService.SetLanguage(Lang);
            var list = new List<LanguagesModel>();
            list.Add(new LanguagesModel { Name = "Afrikaans", Value = "af" });
            list.Add(new LanguagesModel { Name = "English", Value = "en" });
            list.Add(new LanguagesModel { Name = "French", Value = "fr" });
            list.Add(new LanguagesModel { Name = "Swahili", Value = "sw" });
            list.Add(new LanguagesModel { Name = "عربى", Value = "ar" });
            list = list.Where(x => x.Value != Lang).ToList();
            var page = new Login() { Model = list };
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = page.GenerateString();
            wvTest.Navigating -= Shared.wvTest_Navigating;
            wvTest.Navigating += Shared.wvTest_Navigating;
            wvTest.Source = htmlSource;

            var page2 = new LanguageSelector() { Model = list };
            var htmlSource2 = new HtmlWebViewSource();
            htmlSource2.Html = page2.GenerateString();

            wv2.Navigating -= Shared.wvTest_Navigating;
            wv2.Navigating += Shared.wvTest_Navigating;
            wv2.Source = htmlSource2;
        }
        public async void fbError(string result)
        {
            if (result == "User logged in as different Facebook user.")
            {

            }
        }

        public async void fbSuccess(string result)
        {
            var Token = result;
            var FBuser = (App.Current as App).fbUser;
            var user_Id = FBuser.user_Id;

            var handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            string GraphURI = "";
            if (Device.RuntimePlatform == "Android")
                GraphURI = $"https://graph.facebook.com/v12.0/{user_Id}/?access_token={Token}&fields=email,name,picture.type(large)";
            else if (Device.RuntimePlatform == "iOS")
                GraphURI = $"https://graph.facebook.com/v12.0/{user_Id}/me?access_token={Token}&fields=email,name,picture.type(large)";
            var response = await client.GetAsync(GraphURI);
            var content = await response.Content.ReadAsStringAsync();

            var JsonObject = (JObject)JsonConvert.DeserializeObject(content);
            if (JsonObject != null)
            {
                JToken HasEmail;
                if (JsonObject.TryGetValue("email", out HasEmail))
                    FBuser.user_Email = HasEmail.ToString();
                var Username = JsonObject["name"].ToString();
                try
                {
                    Preferences.Set("UserImage", JsonObject["picture"]["data"]["url"].ToString());
                }
                catch
                {
                    Preferences.Set("UserImage", "Sticky/images/download.png");
                }

                SocialMediaLogin UserLogin = new SocialMediaLogin()
                {
                    DeviceID = DependencyService.Get<IGetDeviceInfo>().GetDeviceID(),
                    DeviceToken = null,
                    OS = Xamarin.Essentials.DeviceInfo.Platform.ToString(),
                    OSVersion = Xamarin.Essentials.DeviceInfo.Version.ToString(),
                    SocialMediaID = user_Id,
                    SocialMediaEmail = FBuser.user_Email,
                    SocialMediaName = Username,
                    SocialMediaSite = Shared.SocialSites.Facebook,
                    Lang = Preferences.Get("savedLang", null)
                };
            }

        }

        private void GoogleLogin(object sender, EventArgs e)
        {
            MessagingCenter.Send<App, string>(App.Current as App, "Login", "Google");
        }

        private async void Login(object sender, EventArgs e)
        {
            var frame = sender as FFImageLoading.Svg.Forms.SvgCachedImage;
            MessagingCenter.Send<App, string>(App.Current as App, "Login", frame.AutomationId);

            if (frame.AutomationId == "Apple")
            {
                if (Device.RuntimePlatform == Device.iOS)
                {
                    WebAuthenticatorResult r = null;
                    AppleSignInAuthenticator.Options Options = new AppleSignInAuthenticator.Options() { IncludeEmailScope = true, IncludeFullNameScope = true };
                    r = await AppleSignInAuthenticator.AuthenticateAsync(Options);

                    var authToken = string.Empty;
                    if (r.Properties.TryGetValue("name", out var name) && !string.IsNullOrEmpty(name))
                        authToken += $"Name: {name}{Environment.NewLine}";
                    if (r.Properties.TryGetValue("email", out var email) && !string.IsNullOrEmpty(email))
                        authToken += $"Email: {email}{Environment.NewLine}";

                    // Note that Apple Sign In has an IdToken and not an AccessToken
                    authToken += r?.AccessToken ?? r?.IdToken;
                }
            }
        }
    }
}
