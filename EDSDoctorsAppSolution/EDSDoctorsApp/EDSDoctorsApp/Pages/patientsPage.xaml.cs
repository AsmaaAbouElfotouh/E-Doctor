using EDSDoctorsApp.Helper;
using EDSDoctorsApp.Helper.EMR;
using EDSDoctorsApp.HtmlViews2;
using EDSDoctorsApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EDSDoctorsApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class patientsPage : ContentPage
    {
        string PatientData = "";
        public patientsPage(System.Int32 Page, string sortby = "", string sort = "")
        {
            InitializeComponent();
            LanguageService.SetLanguage(Preferences.Get("savedLang", "en"));
            JArray JsonArray = new JArray();

            PatientData = Shared.GetMainData(new Tuple<string, string, string>("PATIENTS", "Patients", "My Patients"), Page, sortby, sort).Result;
            if (string.IsNullOrWhiteSpace(PatientData))
            {
                PatientData = Preferences.Get("MyPatients", "");
                if (!string.IsNullOrWhiteSpace(PatientData))
                    JsonArray = (JArray)JObject.Parse(PatientData)["result"]["data"];
            }
            else
            {
                Preferences.Set("MyPatients", PatientData);
                JsonArray = (JArray)JObject.Parse(PatientData)["result"]["data"];
            }

            List<PatientVM> PatientsList = new List<PatientVM>();
            foreach (var item in JsonArray)
            {
                PatientsList.Add(new PatientVM()
                {
                    PatientsMRNo = item["PatientsMRNo"].ToString(),
                    Created = Convert.ToDateTime(item["Created"]).ToString("dd-MM-yyyy hh:mm tt"),
                    PatientsName = item["Name"].ToString(),
                    PatientsGender = item["Gender"].ToString(),
                    PatientsNationality = item["Nationality"].ToString(),
                    PatientsAge = Convert.ToDateTime(item["DOB"]).ToShortDateString(),
                    PatientsAccountsID = item["PK"].ToString()
                });
            }

            List<KeyValuePair<string, string>> Statuses = new List<KeyValuePair<string, string>>();
            try
            {
                var GenderFields = Shared.GetMainData(new Tuple<string, string, string>("PATIENTS", "Patients", "My Patients"), 0, "", "", "getMainDataSelectList", "Gender").Result;
                JArray GenderJson = JObject.Parse(GenderFields)["result"] as JArray;
                foreach (var status in GenderJson)
                {
                    Statuses.Add(new KeyValuePair<string, string>(status["id"].ToString(), status["name"].ToString()));
                }
            }
            catch
            { }

            var page = new patients() { Model = (PatientsList, Page <= 0 ? 1 : Page, Statuses, App.Between(sort, "Between ", " AND").Trim('\'')) };
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = page.GenerateString();
            wvTest.Navigating += Shared.wvTest_Navigating;
            wvTest.Source = htmlSource;
        }
    }
}