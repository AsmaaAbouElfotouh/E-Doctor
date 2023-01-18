using EDSDoctorsApp.Helper;
using EDSDoctorsApp.HtmlViews;
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
    public partial class RegWizardPage : ContentPage
    {
        public RegWizardPage()
        {
            InitializeComponent();
            LanguageService.SetLanguage(Preferences.Get("savedLang", "en"));

            //Open view for the first time
            var page = new RegWizard();
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = page.GenerateString();
            wvTest.Navigating += Shared.wvTest_Navigating;
            wvTest.Source = htmlSource;
        }

        private void GoBack(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PopAsync();
        }

        private void Continue_Registration(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new RegWizardPage_2());
        }
    }
}