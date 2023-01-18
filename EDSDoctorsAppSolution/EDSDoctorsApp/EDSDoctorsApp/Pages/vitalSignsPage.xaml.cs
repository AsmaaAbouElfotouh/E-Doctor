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
    public partial class vitalSignsPage : ContentPage
    {
        public vitalSignsPage()
        {
            InitializeComponent();
            LanguageService.SetLanguage(Preferences.Get("savedLang", "en"));

            var VitalsData = Shared.PostAPI($"api/Paitent/{Preferences.Get("savedCulture", "en-GB")}/EMR/loadvitals?patientid={App.PatientEMR.Id}&visitid=&skip=0", "{}", false, "GET");
            var VitalsJson = JObject.Parse(VitalsData)["result"].ToString();
            var Vitals = JsonConvert.DeserializeObject<List<PatientsVital>>(VitalsJson);


            //var TrackerData = Shared.PostAPI($"api/Paitent/{Preferences.Get("savedCulture", "en-GB")}/EMR/EmrTracker?PID={App.PatientEMR.Id}&RID={SecureStorage.GetAsync("ResourceID").Result}", "{}", false, "GET");
            //var TrackerJson = JObject.Parse(TrackerData)["result"].ToString();
            //var Trackers = JsonConvert.DeserializeObject<List<VmTrackeBySection>>(VitalsJson);
            //var vitals = Trackers.Where(a => a.Section == "Vitals").FirstOrDefault();
            //List<VmTrackers> numaric = vitals.Trackes.NumericTracker.ToList();
            List<VmTrackers> numaric = new List<VmTrackers>();
            var page = new vitalSigns() { Model =(Vitals, numaric) };
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = page.GenerateString();
            wvTest.Navigating += Shared.wvTest_Navigating;
            wvTest.Source = htmlSource;
        }
    }
}