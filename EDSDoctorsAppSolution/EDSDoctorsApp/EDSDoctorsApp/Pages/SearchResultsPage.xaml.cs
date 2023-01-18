using System;
using System.Collections.Generic;
using EDSDoctorsApp.Helper;
using EDSDoctorsApp.HtmlViews;
using EDSDoctorsApp.ViewModels;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EDSDoctorsApp.Pages
{
    public partial class SearchResultsPage : ContentPage
    {
        public SearchResultsPage(string searchSort, string strCareerLvl, string strGender , bool SearchPatients)
        {
            InitializeComponent();

            var Lang = Preferences.Get("savedLang", "en");
            LanguageService.SetLanguage(Lang);

            string strSpeciality = Preferences.Get("SearchSpecialtyID", null);
            string strCountryName = Preferences.Get("Country", null);
            string strCityName = Preferences.Get("SearchCity", null);
            string strDistrictName = Preferences.Get("SearchDistrict", null);
            string strDoctorName = Preferences.Get("SearchDoctorName", "");
            string strSourceView = Preferences.Get("SourceView", "");

            Dispatcher.BeginInvokeOnMainThread(async() =>
            {
                string strPGUID = await SecureStorage.GetAsync("PatientsGuid");


                //  string strSorting = !string.IsNullOrWhiteSpace(Intent.GetStringExtra("SearchSort")) ? Intent.GetStringExtra("SearchSort") : null;
                // string strCareerLvl = !string.IsNullOrWhiteSpace(Intent.GetStringExtra("SearchCareerLevel")) ? Intent.GetStringExtra("SearchCareerLevel") : null;
                //  string strGender = !string.IsNullOrWhiteSpace(Intent.GetStringExtra("SearchGender")) ? Intent.GetStringExtra("SearchGender") : null;

                //Open view for the first time
                dynamic obj = new
                {
                    Speciality = strSpeciality,
                    Country = strCountryName,
                    City = strCityName,
                    District = strDistrictName,
                    Lang = Lang,
                    Page = "1",
                    Sort = searchSort,
                    CareerLevel = strCareerLvl,
                    Gender = strGender,
                    DoctorName = strDoctorName,
                    PGUID = strPGUID,
                    LastView = "GoTo" + strSourceView + "Back"
                };


                var Result = Shared.PostAPI("SearchDoctors", JsonConvert.SerializeObject(obj));
                if (Result == null)
                    return;
                List<FindDoctors> FindDoctors = JsonConvert.DeserializeObject<List<FindDoctors>>(Result);
                FindDoctors.ForEach(x => x.Address = (!string.IsNullOrWhiteSpace(x.LocationsWebProfileAddress)) ? x.LocationsWebProfileAddress : (x.Country == "" ? "" : x.Country + " - ") + (x.City == "" ? "" : x.City + " - ") + (x.District == "" ? "" : x.District + " - ") + (x.Building == "" ? "" : x.Building + " - ") + (x.Street == "" ? "" : x.Street + ""));

                VMDoctors vMDoctors = new VMDoctors() { Doctors = new List<FindDoctors>(), Search = obj };
                var htmlSource = new HtmlWebViewSource();
                if (SearchPatients)
                {
                    var page = new SearchPatients() { Model = vMDoctors };
                    htmlSource.Html = page.GenerateString();
                }
                else
                {
                    var page = new SearchBookings() { Model = vMDoctors };
                    htmlSource.Html = page.GenerateString();
                }
                wvTest.Navigating += Shared.wvTest_Navigating;                
                wvTest.Source = htmlSource;
            });
        }
    }
}
