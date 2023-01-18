using EDSDoctorsApp.Helper;
using EDSDoctorsApp.HtmlViews2;
using EDSDoctorsApp.Models;
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
    public partial class bookingPage : ContentPage
    {
        string TodayVisitsData = "";
        string AllVisitsData = "";
        public bookingPage(int Page,string sortby = "",string sort = "")
        {
            InitializeComponent();
            LanguageService.SetLanguage(Preferences.Get("savedLang", "en"));
            JArray JsonArray = new JArray();
            JArray JsonArray2 = new JArray();
            JArray StatusesJson = new JArray();
            JArray LocationJson = new JArray();

            TodayVisitsData = Shared.GetMainData(new Tuple<string, string, string>("Outpatient", "vmdVisits", "Today's Visits"),Page,sortby,sort,ExtraColumns: ",dbo.fnGetLocationPath(VisitsLocationsID) as [Location]").Result;
            if (TodayVisitsData == null)
            {
                TodayVisitsData = Preferences.Get("TodayVisits", "");
                if (!string.IsNullOrWhiteSpace(TodayVisitsData))
                    JsonArray = (JArray)JObject.Parse(TodayVisitsData)["result"]["data"];
            }
            else
            {
                JsonArray = (JArray)JObject.Parse(TodayVisitsData)["result"]["data"];
                foreach (var visit in JsonArray)
                {
                    Shared.GetAllPatientEMR(visit["PK"].ToString());
                }
                Preferences.Set("TodayVisits", TodayVisitsData);
            }

            AllVisitsData = Shared.GetMainData(new Tuple<string, string, string>("Outpatient", "vmdVisits", "All Visits"),Page,sortby,sort).Result;
            if (AllVisitsData == null)
            {
                AllVisitsData = Preferences.Get("AllVisits", "");
                if(!string.IsNullOrWhiteSpace(AllVisitsData))
                JsonArray2 = (JArray)JObject.Parse(AllVisitsData)["result"]["data"];
            }
            else
            {
                Preferences.Set("AllVisits", AllVisitsData);
                JsonArray2 = (JArray)JObject.Parse(AllVisitsData)["result"]["data"];
            }

            var StatusFields = Shared.GetMainData(new Tuple<string, string, string>("Outpatient", "vmdVisits", "All Visits"),1,"","","getMainDataSelectList","VisitsStatus").Result;
            if (StatusFields != null)
                StatusesJson = JObject.Parse(StatusFields)["result"] as JArray;

            List<KeyValuePair<string, string>> Statuses = new List<KeyValuePair<string, string>>();
            foreach (var status in StatusesJson)
            {
                Statuses.Add(new KeyValuePair<string, string>(status["id"].ToString(), status["name"].ToString()));
            }

            var result = Shared.PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/Account/getPhysicianLocations", JsonConvert.SerializeObject(new { resourcesId = SecureStorage.GetAsync("ResourceID").Result, accountsId = SecureStorage.GetAsync("AccountID").Result }));
            if (result == null)
            {
                result = Preferences.Get("AllLocations", "");
                if (!string.IsNullOrWhiteSpace(result))
                    LocationJson = JObject.Parse(result)["result"] as JArray;
            }
            else
            {
                Preferences.Set("AllLocations", result);
                LocationJson = JObject.Parse(result)["result"] as JArray;
            }
            var DoctorLocations = new List<KeyValuePair<string, string>>();
            foreach (var item in LocationJson)
            {
                DoctorLocations.Add(new KeyValuePair<string, string>(item["id"].ToString(), item["name"].ToString()));
            }

            List<VisitsVM> TodayVisitsList = new List<VisitsVM>();
            List<VisitsVM> AllVisitsList = new List<VisitsVM>();

            foreach (var item in JsonArray)
            {
                TodayVisitsList.Add(new VisitsVM() 
                {
                    VisitsPatientsId = Guid.Parse(item["PK"].ToString()),
                    VisitsSndep = item["SND"].Type == JTokenType.Null ? 0 : (long)item["SND"],
                    VisitsbookingPatientName = item["Name"].ToString(),
                    VisitsType = item["VisitsType"].ToString(),
                    VisitsCategory = item["VisitsCategory"].ToString(),
                    VisitsStatus = item["VisitsStatus"].ToString(),
                    VisitsScheduleDateTime = Convert.ToDateTime(item["VisitsScheduleDateTime"]).ToString("mm/dd/yyyy hh:mm tt"),
                    Created = Convert.ToDateTime(item["Created"]).ToString("mm-dd-yyyy hh:mm"),
                    VisitActions = item["ConditionPermission"].ToString().Contains('|') ? item["ConditionPermission"].ToString().Split('|').ToList() : new List<string> { item["ConditionPermission"].ToString() },
                    VisitLocation = item["Location"].ToString()

                });
            }

            foreach (var item in JsonArray2)
            {
                AllVisitsList.Add(new VisitsVM()
                {
                    VisitsPatientsId = Guid.Parse(item["PK"].ToString()),
                    VisitsSndep = item["SND"].Type == JTokenType.Null ? 0 : (long)item["SND"],
                    VisitsbookingPatientName = item["Name"].ToString(),
                    VisitsType = item["VisitsType"].ToString(),
                    VisitsCategory = item["VisitsCategory"].ToString(),
                    VisitsStatus = item["VisitsStatus"].ToString(),
                    VisitsScheduleDateTime = Convert.ToDateTime(item["VisitsScheduleDateTime"]).ToString("mm/dd/yyyy hh:mm tt"),
                    Created = Convert.ToDateTime(item["Created"]).ToString("mm-dd-yyyy hh:mm"),
                    VisitActions = item["ConditionPermission"].ToString().Contains('|') ? item["ConditionPermission"].ToString().Split('|').ToList() : new List<string> { item["ConditionPermission"].ToString() },
                    VisitLocation = item["Location"].ToString()
                });
            }

            //Open view for the first time
            var page = new booking() { Model = (string.IsNullOrWhiteSpace(sort) ? TodayVisitsList : TodayVisitsList.Where(x=>x.VisitLocation == sort).ToList(),AllVisitsList,Statuses,Page, DoctorLocations) };
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = page.GenerateString();
            wvTest.Navigating += Shared.wvTest_Navigating;
            wvTest.Source = htmlSource;
        }
    }
}