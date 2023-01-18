using System;
using System.Collections.Generic;
using System.Linq;
using EDSDoctorsApp.APIs.Account;
using EDSDoctorsApp.APIs.HR;
using EDSDoctorsApp.Helper;
using EDSDoctorsApp.HtmlViews;
using EDSDoctorsApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EDSDoctorsApp.Pages
{
    public partial class MyProfilePage : ContentPage
    {
        public MyProfilePage()
        {
            InitializeComponent();
            var Lang = Preferences.Get("savedLang", "en");
            var list = new List<LanguagesModel>();
            list.Add(new LanguagesModel { Name = "Afrikaans", Value = "af" });
            list.Add(new LanguagesModel { Name = "English", Value = "en" });
            list.Add(new LanguagesModel { Name = "French", Value = "fr" });
            list.Add(new LanguagesModel { Name = "Swahili", Value = "sw" });
            list.Add(new LanguagesModel { Name = "عربى", Value = "ar" });
            list = list.Where(x => x.Value != Lang).ToList();            
            LanguageService.SetLanguage(Lang);

            var LocationsList = new List<TreeResponseModel>();
            var MySchedulesList = new List<MySchedules>();
            var AllSpecialties = new List<APIs.Account.DropDownListModel>();
            var AllCareers = new List<APIs.Account.DropDownListModel>();

            var ProfileResult = Shared.PostAPI($"api/HR/{Preferences.Get("savedCulture", "en-GB")}/StaffSetting/getStaffSetting?id=" + SecureStorage.GetAsync("ResourceID").Result);
            if (string.IsNullOrWhiteSpace(ProfileResult))
                ProfileResult = Preferences.Get("ProfileData", "");
            else
                Preferences.Set("ProfileData", ProfileResult);
            try
            {
                var ProfileData = JsonConvert.DeserializeObject<APIs.HR.ResponseOfStaffModel>(ProfileResult);
                var Profile = ProfileData.Result;
                App.DoctorProfile = Profile;
            }
            catch
            {
                App.DoctorProfile.ResourcesStaff = new APIs.HR.ResourcesStaff();
            }

            var DoctorResult = Shared.PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/Staff/getStaffDetails?id=" + SecureStorage.GetAsync("ResourceID").Result);
            if (string.IsNullOrWhiteSpace(DoctorResult))
                DoctorResult = Preferences.Get("ProfileStaff", "");
            else
                Preferences.Set("ProfileStaff", DoctorResult);
            try
            {
                var DoctorData = JsonConvert.DeserializeObject<APIs.Account.ResponseOfStaffModel>(DoctorResult);
                var Doctor = DoctorData.Result;
                App.StaffProfile = Doctor;
            }
            catch
            {
                
            }

            var AllSpecialtiesResult = Shared.PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/Account/getAllSpectialties");
            if (string.IsNullOrWhiteSpace(AllSpecialtiesResult))
                AllSpecialtiesResult = Preferences.Get("AllSpecialties", "");
            else
                Preferences.Set("AllSpecialties", AllSpecialtiesResult);
            try
            {
                var AllSpecialtiesData = JsonConvert.DeserializeObject<APIs.Account.ResponseOfListOfDropDownListModel>(AllSpecialtiesResult);
                AllSpecialties = AllSpecialtiesData.Result.ToList<APIs.Account.DropDownListModel>();
            }
            catch
            { }

            var AllCareersResult = Shared.PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/Account/getCareerLevels", "{}");
            if (string.IsNullOrWhiteSpace(AllCareersResult))
                AllCareersResult = Preferences.Get("AllCareers", "");
            else
                Preferences.Set("AllCareers", AllCareersResult);
            try
            {
                var AllCareersData = JsonConvert.DeserializeObject<APIs.Account.ResponseOfListOfDropDownListModel>(AllCareersResult);
                AllCareers = AllCareersData.Result.ToList<APIs.Account.DropDownListModel>();
            }
            catch
            { }

            var LocationsResult = Shared.GetTreeData(new Tuple<string, string, string>("GeneralSettings", "Locations", "All"),1,"getTreeData", "LocationsName").Result;
            if (string.IsNullOrWhiteSpace(LocationsResult))
                LocationsResult = Preferences.Get("LocationsResult", "");
            else
                Preferences.Set("LocationsResult", LocationsResult);
            try
            {
                var LocationsData = JObject.Parse(LocationsResult)["result"].ToString();
                LocationsList = JsonConvert.DeserializeObject<List<TreeResponseModel>>(LocationsData);
            }
            catch
            { }

            var SchedulesResult = Shared.GetMainData(new Tuple<string, string, string>("GeneralSettings", "Schedules", "MySchedules"), EndPoint: "getMainData",length:20).Result;
            if (string.IsNullOrWhiteSpace(SchedulesResult))
                SchedulesResult = Preferences.Get("SchedulesResult", "");
            else
                Preferences.Set("SchedulesResult", SchedulesResult);
            try
            {
                MySchedulesList = JsonConvert.DeserializeObject<List<MySchedules>>(JObject.Parse(SchedulesResult)["result"]["data"].ToString());
            }
            catch
            { }
            //var MySchedulesArray = JArray.Parse(MySchedules).Where(x=>x["SchedulesResourcesID"].ToString() == SecureStorage.GetAsync("ResourceID").Result).ToList();
            //var MySchedulesList = new List<SchedulesResponse>();
            //foreach (var Schedule in MySchedulesArray)
            //    MySchedulesList.Add(Schedule.ToObject<SchedulesResponse>());


            //Open view for the first time
            var page = new MyProfile() { Model = (LocationsList,MySchedulesList , App.DoctorProfile, App.StaffProfile,AllSpecialties,AllCareers) };
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = page.GenerateString();
            wvTest.Navigating += Shared.wvTest_Navigating;
            wvTest.Source = htmlSource;
        }
    }
}
