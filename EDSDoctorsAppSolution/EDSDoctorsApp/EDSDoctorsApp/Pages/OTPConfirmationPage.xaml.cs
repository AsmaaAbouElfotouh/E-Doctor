using System;
using System.Collections.Generic;
using EDSDoctorsApp.Helper;
using EDSDoctorsApp.HtmlViews;
using EDSDoctorsApp.Models;
using EDSDoctorsApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EDSDoctorsApp.Pages
{
    public partial class OTPConfirmationPage : ContentPage
    {
        public OTPConfirmationPage(ConfirmEmailModel user)
        {
            InitializeComponent();
            LanguageService.SetLanguage(Preferences.Get("savedLang", "en"));

            //Open view for the first time
            var page = new OTPConfirmation() { Model = user };
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = page.GenerateString();
            wvTest.Navigating += Shared.wvTest_Navigating;
            wvTest.Source = htmlSource;
        }
    }
}
