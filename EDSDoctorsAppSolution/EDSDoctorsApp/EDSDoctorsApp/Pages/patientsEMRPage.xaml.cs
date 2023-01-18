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
    public partial class patientsEMRPage : ContentPage
    {
        public patientsEMRPage()
        {
            InitializeComponent();
            LanguageService.SetLanguage(Preferences.Get("savedLang", "en"));
            JObject Data = new JObject();
            List<DropDownListModel> ReviewOfSystems = new List<DropDownListModel>();
            List<DropDownListModel> RiskFactors = new List<DropDownListModel>();
            List<DropDownListModel> ChronicDiseases = new List<DropDownListModel>();
            List<DropDownListModel> PhobiaTypes = new List<DropDownListModel>();
            List<DropDownListModel> SocialHabits = new List<DropDownListModel>();
            List<GroupExaminationVm> TimelineList = new List<GroupExaminationVm>();

            var TimelineData = Shared.PostAPI($"api/Paitent/{Preferences.Get("savedCulture", "en-GB")}/PatientsEmr/loadtimeline?Id={App.PatientEMR.Id}", JsonConvert.SerializeObject(new { id = App.PatientEMR.Id }));
            if (!string.IsNullOrWhiteSpace(TimelineData))
            Preferences.Set(App.PatientID, TimelineData, "PatientTimeline");
            else
            TimelineData = Preferences.Get(App.PatientID, "", "PatientTimeline");

            if (!string.IsNullOrWhiteSpace(TimelineData))
            {
                Data = JObject.Parse(TimelineData);
                foreach (var Timeline in Data["result"])
                {
                    TimelineList.Add(new GroupExaminationVm()
                    {
                        TimeLineMonth = Timeline["timeLineMonth"].ToString(),
                        Exams = JsonConvert.DeserializeObject<ICollection<ExaminationTimeVm>>(Timeline["exams"].ToString())
                    });
                }
            }

            //var TimeLineAttachments = Shared.PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/Account/GetAttachedFiles?AccountsID={SecureStorage.GetAsync("AccountID").Result}&ParentID={App.PatientEMR.PatientsEMR.Id}&Type=Examination", JsonConvert.SerializeObject(new { id = App.PatientEMR.Id }));
            

            var ReviewOfSystemsJson = Shared.PostAPI($"api/Paitent/{Preferences.Get("savedCulture", "en-GB")}/PatientsEmr/getReviewOfSystems", "{}");
            if(!string.IsNullOrWhiteSpace(ReviewOfSystemsJson))
            ReviewOfSystems = JsonConvert.DeserializeObject<List<DropDownListModel>>(JObject.Parse(ReviewOfSystemsJson)["result"].ToString());

            var PatientReviewOfSystems = Shared.PostAPI($"api/Paitent/{Preferences.Get("savedCulture", "en-GB")}/PatientsEmr/getPatientReviewOfSystems?id={App.PatientEMR.Id}", JsonConvert.SerializeObject(new { id = App.PatientEMR.Id }));

            try
            {

                var RiskFactorsJson = JObject.Parse(Shared.GetDynamicLists("Risk Factors").Result)["result"].ToString();
                if (!string.IsNullOrWhiteSpace(RiskFactorsJson))
                    RiskFactors = JsonConvert.DeserializeObject<List<DropDownListModel>>(RiskFactorsJson);

                var ChronicDiseasesJson = JObject.Parse(Shared.GetDynamicLists("Chronic Disease").Result)["result"].ToString();
                if (!string.IsNullOrWhiteSpace(ChronicDiseasesJson))
                    ChronicDiseases = JsonConvert.DeserializeObject<List<DropDownListModel>>(ChronicDiseasesJson);

                var PhobiaTypesJson = JObject.Parse(Shared.GetDynamicLists("PhobiaTypes").Result)["result"].ToString();
                if (!string.IsNullOrWhiteSpace(PhobiaTypesJson))
                    PhobiaTypes = JsonConvert.DeserializeObject<List<DropDownListModel>>(PhobiaTypesJson);

                var SocialHabitsJson = JObject.Parse(Shared.GetDynamicLists("SocialHabits").Result)["result"].ToString();
                if (!string.IsNullOrWhiteSpace(SocialHabitsJson))
                    SocialHabits = JsonConvert.DeserializeObject<List<DropDownListModel>>(SocialHabitsJson);
            }
            catch
            { }            

           

            var page = new patientsEMR() { Model = (TimelineList, App.PatientEMR.PatientsName, App.PatientEMR.PatientsMRNo, RiskFactors, ChronicDiseases, PhobiaTypes,ReviewOfSystems, PatientReviewOfSystems, App.PatientEMR.Id) };
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = page.GenerateString();
            wvTest.Navigating += Shared.wvTest_Navigating;
            wvTest.Source = htmlSource;
        }
    }
}