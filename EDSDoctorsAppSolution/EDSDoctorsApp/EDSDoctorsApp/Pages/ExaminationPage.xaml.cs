using EDSDoctorsApp.Helper;
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
using EDSDoctorsApp.APIs.Account;
using EDSDoctorsApp.APIs.Patients;

namespace EDSDoctorsApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExaminationPage : ContentPage
    {
        public ExaminationPage(string ExamID = "")
        {
            InitializeComponent();
            LanguageService.SetLanguage(Preferences.Get("savedLang", "en"));
            
            List<CustomFieldVM> customFields = new List<CustomFieldVM>();
            List<ExaminationInvestigation> AllInvestigationsData = new List<ExaminationInvestigation>();
            List<ExaminationTreatment> ExamTreatments = new List<ExaminationTreatment>();
            List<VmAttachments> ExamAttachmentsData = new List<VmAttachments>();

            string[] Sections = { "Chief Complaint", "Diagnosis", "Examination", "Physiotherapy", "Procedure", "Provisional" };
            foreach (var item in Sections)
            {
                EMRFilter eMRFilter = new EMRFilter() { PatientID = App.PatientID, Rid = SecureStorage.GetAsync("ResourceID").Result, IsTemp = false, Section = item, ExamID = ExamID };

                var custom = Shared.PostAPI($"api/Paitent/{Preferences.Get("savedCulture", "en-GB")}/EMR/GetExaminationsDataSection", JsonConvert.SerializeObject(eMRFilter));

                var customField = JObject.Parse(custom)["result"].ToString();
                customFields.AddRange(JsonConvert.DeserializeObject<List<CustomFieldVM>>(customField));
            }

            if (!string.IsNullOrWhiteSpace(ExamID))
            {
                var AllInvestigations = Shared.PostAPI($"api/Paitent/{Preferences.Get("savedCulture", "en-GB")}/EMR/loadinvestigations?id=" + ExamID, "{}");
                AllInvestigationsData = JsonConvert.DeserializeObject<ResponseOfListOfExaminationInvestigation>(AllInvestigations).Result.ToList();
                var ExamTreatmentsData = Shared.PostAPI($"api/Paitent/{Preferences.Get("savedCulture", "en-GB")}/EMR/loadtreatments?id=" + ExamID, JsonConvert.SerializeObject(new { id=ExamID }));
                ExamTreatments = JsonConvert.DeserializeObject<List<ExaminationTreatment>>(JObject.Parse(ExamTreatmentsData)["result"].ToString());
                
                var ExamAttachments = Shared.PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/Account/GetAttachedFiles?AccountsID={SecureStorage.GetAsync("AccountID").Result}&ParentID={ExamID}&Type=Examination", JsonConvert.SerializeObject(new { id = App.PatientEMR.Id }));

                ExamAttachmentsData = JsonConvert.DeserializeObject<ResponseOfListOfvmAttachments>(ExamAttachments).Result.ToList();


            }

            List<APIs.Account.DropDownListModel> TreatmentsForm = JsonConvert.DeserializeObject<List<APIs.Account.DropDownListModel>>(JObject.Parse(Shared.GetDynamicLists("Treatments Form").Result)["result"].ToString());
            List<APIs.Account.DropDownListModel> TreatmentsRoute = JsonConvert.DeserializeObject<List<APIs.Account.DropDownListModel>>(JObject.Parse(Shared.GetDynamicLists("Treatments Route").Result)["result"].ToString());
            List<APIs.Account.DropDownListModel> TreatmentsUnit = JsonConvert.DeserializeObject<List<APIs.Account.DropDownListModel>>(JObject.Parse(Shared.GetDynamicLists("Treatments Unit").Result)["result"].ToString());



            //Open view for the first time
            var page = new examination() { Model = (customFields, Sections, SecureStorage.GetAsync("ResourceID").Result, AllInvestigationsData,TreatmentsForm,TreatmentsRoute,TreatmentsUnit,ExamTreatments,ExamID, ExamAttachmentsData) };
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = page.GenerateString();
            wvTest.Navigating += Shared.wvTest_Navigating;
            wvTest.Source = htmlSource;
        }
    }
}