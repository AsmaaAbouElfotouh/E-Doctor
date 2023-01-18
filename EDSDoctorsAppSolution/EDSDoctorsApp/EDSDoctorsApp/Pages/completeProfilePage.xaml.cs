using EDSDoctorsApp.Helper;
using EDSDoctorsApp.Helper.EMR;
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
    public partial class completeProfilePage : ContentPage
    {
        public completeProfilePage()
        {
            InitializeComponent();
            LanguageService.SetLanguage(Preferences.Get("savedLang", "en"));
            //Gender
            var GenderResult = Shared.PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/Account/GetDynamicListMenusItems", JsonConvert.SerializeObject(new { dynamicListMenusName = "Gender" }));
            var GenderData = JObject.Parse(GenderResult)["result"].ToString();

            //Degree
            var DegreeResult = Shared.PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/Account/GetDynamicListMenusItems", JsonConvert.SerializeObject(new { dynamicListMenusName = "ScientificDegree" }));
            var DegreeData = JObject.Parse(DegreeResult)["result"].ToString();

            //Speciality
            AccountsRequestParameter prm = new AccountsRequestParameter();
            prm.AccountsId = SecureStorage.GetAsync("AccountID").ToString();
            var SpecialtiesResult = Shared.PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/Account/getAllSpectialties", JsonConvert.SerializeObject(new { data = prm }));
            var SpecialtiesData = JObject.Parse(SpecialtiesResult)["result"].ToString();

            //Country
            var CountriesResult = Shared.PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/Account/GetDynamicListMenusItems", JsonConvert.SerializeObject(new { dynamicListMenusName = "Countries" }));
            var CountriesData = JObject.Parse(CountriesResult)["result"].ToString();

            //City
            var CitiesResult = Shared.PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/Account/GetDynamicListMenusItems", JsonConvert.SerializeObject(new { dynamicListMenusName = "Cities" }));
            var CitiesData = JObject.Parse(CitiesResult)["result"].ToString();

            //District
            var DistrictsResult = Shared.PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/Account/GetDynamicListMenusItems", JsonConvert.SerializeObject(new { dynamicListMenusName = "Districts" }));
            var DistrictsData = JObject.Parse(DistrictsResult)["result"].ToString();
            //var username = SecureStorage.GetAsync("userEmail");

            CompleteProfileViews views = new CompleteProfileViews();
            views.Gender = JsonConvert.DeserializeObject<List<DropDownListModel>>(GenderData);
            views.Degree = JsonConvert.DeserializeObject<List<DropDownListModel>>(DegreeData);
            views.Specialties = JsonConvert.DeserializeObject<List<DropDownListModel>>(SpecialtiesData);
            views.Countries = JsonConvert.DeserializeObject<List<DropDownListModel>>(CountriesData);
            views.Cities = JsonConvert.DeserializeObject<List<DropDownListModel>>(CitiesData);
            views.Districts = JsonConvert.DeserializeObject<List<DropDownListModel>>(DistrictsData);
            //Open view for the first CitiesData
            var page = new compeletProfile() {Model = views };
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = page.GenerateString();
            wvTest.Navigating += Shared.wvTest_Navigating;
            wvTest.Source = htmlSource;
        }
    }
}