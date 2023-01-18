using System;
using System.Collections.Generic;
using EDSDoctorsApp.Helper;
using EDSDoctorsApp.HtmlViews;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EDSDoctorsApp.Pages
{
    public partial class ChangePasswordPage : ContentPage
    {
        public ChangePasswordPage()
        {
            InitializeComponent();
            LanguageService.SetLanguage(Preferences.Get("savedLang", "en"));

            //Open view for the first time
            var page = new ChangePassword();
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = page.GenerateString();
            wvTest.Navigating += Shared.wvTest_Navigating;
            wvTest.Source = htmlSource;
        }
    }
}
