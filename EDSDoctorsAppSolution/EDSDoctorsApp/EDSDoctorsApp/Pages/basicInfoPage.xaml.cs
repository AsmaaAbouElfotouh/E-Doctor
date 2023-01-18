using EDSDoctorsApp.Helper;
using EDSDoctorsApp.HtmlViews2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EDSDoctorsApp.APIs.Account;
using Newtonsoft.Json.Linq;

namespace EDSDoctorsApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class basicInfoPage : ContentPage
    {
        public basicInfoPage()
        {
            InitializeComponent();
            LanguageService.SetLanguage(Preferences.Get("savedLang", "en"));

            var PatientAttachmentsData = Shared.PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/Account/GetAttachedFiles?AccountsID={SecureStorage.GetAsync("AccountID").Result}&ParentID={App.PatientEMR.Id}&Type=Patient", "{}");

            var PatientAttachments = JsonConvert.DeserializeObject<ResponseOfListOfvmAttachments>(PatientAttachmentsData);
            var PatientAttachmentsList = PatientAttachments.Result.ToList();

            //Open view for the first time
            var page = new basicInfo() { Model = PatientAttachmentsList  };
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = page.GenerateString();
            wvTest.Navigating += Shared.wvTest_Navigating;
            wvTest.Source = htmlSource;
        }
    }
}