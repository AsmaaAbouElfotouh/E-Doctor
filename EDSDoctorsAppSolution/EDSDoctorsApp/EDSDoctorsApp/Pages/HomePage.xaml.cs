using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EDSDoctorsApp.HtmlViews;
using EDSDoctorsApp.HtmlViews2;
using EDSDoctorsApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EDSDoctorsApp.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            wvTest.Navigating += Shared.wvTest_Navigating;
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            if (Preferences.Get("CompleteRegistration", false))
            {
                Preferences.Set("CompleteRegistration", false);
                var page = new compeletProfile();
                var htmlSource = new HtmlWebViewSource();
                htmlSource.Html = page.GenerateString();
                wvTest.Source = htmlSource;
            }
            else
            {
                var page = new Home();
                var htmlSource = new HtmlWebViewSource();
                htmlSource.Html = page.GenerateString();
                wvTest.Source = htmlSource;
            }
        }
    }
}
