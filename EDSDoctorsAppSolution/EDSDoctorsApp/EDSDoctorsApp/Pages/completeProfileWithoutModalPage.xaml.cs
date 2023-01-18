using EDSDoctorsApp.Helper;
using EDSDoctorsApp.HtmlViews2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EDSDoctorsApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class completeProfileWithoutModalPage : ContentPage
    {
        public completeProfileWithoutModalPage()
        {
            InitializeComponent();
            LanguageService.SetLanguage(Preferences.Get("savedLang", "en"));

            //Open view for the first time
            var page = new compeletProfileWithoutModal() { };
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = page.GenerateString();
            wvTest.Navigating += Shared.wvTest_Navigating;
            wvTest.Source = htmlSource;
        }
    }
}