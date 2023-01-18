using EDSDoctorsApp.Helper;
using EDSDoctorsApp.Helper.EMR;
using EDSDoctorsApp.HtmlViews2;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class galleryPage : ContentPage
    {
        public galleryPage()
        {
            InitializeComponent();
            LanguageService.SetLanguage(Preferences.Get("savedLang", "en"));

            var GalleryJson = Shared.PostAPI($"api/Paitent/{Preferences.Get("savedCulture", "en-GB")}/PatientsEmr/loadGallary?Id={App.PatientID}&page=1", JsonConvert.SerializeObject(new { Id = App.PatientID , page = 1 }));
            var GalleryData = JObject.Parse(GalleryJson)["result"].ToString();
            var GalleryItems = JsonConvert.DeserializeObject<List<GallaryVm>>(GalleryData);

            var page = new gallery() { Model = GalleryItems };
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = page.GenerateString();
            wvTest.Navigating += Shared.wvTest_Navigating;
            wvTest.Source = htmlSource;
        }
    }
}