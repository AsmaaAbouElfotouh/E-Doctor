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
    public partial class RegWizardPage_2 : ContentPage
    {
        public RegWizardPage_2()
        {
            InitializeComponent();
            LanguageService.SetLanguage(Preferences.Get("savedLang", "en"));

            //Open view for the first time
            var page = new RegWizard_2();
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = page.GenerateString();
            wvTest.Navigating += Shared.wvTest_Navigating;
            wvTest.Source = htmlSource;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PopAsync();
        }

        private void Add_Address(object sender, EventArgs e)
        {
            App.Refresh_Page();
        }

        private void Goto_Homepage(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new HomePage());
        }
    }
}