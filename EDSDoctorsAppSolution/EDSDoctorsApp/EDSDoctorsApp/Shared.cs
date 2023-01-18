using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EDSDoctorsApp.Helper;
using EDSDoctorsApp.Helper.EMR;
using EDSDoctorsApp.Models;
using EDSDoctorsApp.Pages;
using EDSDoctorsApp.Resources;
using EDSDoctorsApp.ViewModels;
//using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EDSDoctorsApp
{
    public class Shared
    {
        public async static void wvTest_Navigating(object sender, WebNavigatingEventArgs e)
        {
            Uri request;
            try
            {
                request = new Uri(e.Url);
            }
            catch
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(request.AbsoluteUri))
                return;
            if (!request.Scheme.ToLower().StartsWith("hybrid")) return;

            e.Cancel = true;
            await App.Current.MainPage.Navigation.PushPopupAsync(new LoaderPage(), true);

            string strAction = request.AbsolutePath;

            string strQueryParams = request.Query;
            NameValueCollection parameters = new NameValueCollection();
            if (!string.IsNullOrWhiteSpace(strQueryParams)) parameters = HttpUtility.ParseQueryString(strQueryParams);


            switch (strAction.ToLower())
            {
                case "gotologin":
                    App.Current.MainPage = new NavigationPage(new LoginPage());
                    break;

                case "dologin":

                    if (string.IsNullOrEmpty(parameters["email"]) && string.IsNullOrEmpty(parameters["password"]))
                    {
                        //Empty Data, show message to user
                        App.Current.MainPage.DisplayAlert("", AppResources.FillAllRequiredFields, "OK");

                    }
                    else
                    {
                        UserLogin userLogin = new UserLogin();
                        userLogin.email = parameters["email"];
                        userLogin.password = parameters["password"];

                        //Call Login Backend API to validate user credentials
                        var Result = Shared.PostAPI($"api/Authenticate/{Preferences.Get("savedCulture", "en-GB")}/Authenticate/login/false", JsonConvert.SerializeObject(userLogin), true);
                        if (string.IsNullOrEmpty(Result))
                        {
                            App.Current.MainPage.Navigation.PopAllPopupAsync();
                            return;
                        }
                        LoginUser loginUser = JsonConvert.DeserializeObject<LoginUser>(Result);

                        if (!string.IsNullOrWhiteSpace(loginUser.errorMessage))
                        {
                            //Invalid Login, add credentials in temp variable, and show message to user
                            //App.Current.MainPage.DisplayAlert("", AppResources.InvalidLogin, "OK");
                            ShowMessage(sender as WebView, AppResources.InvalidLogin);
                        }
                        else
                        {
                            #region Keep UserLoggedin
                            var LoginResponse = JObject.Parse(Result)["result"];
                            await SecureStorage.SetAsync("credEncrypted", LoginResponse["credEncrypted"].ToString());
                            await SecureStorage.SetAsync("userToken", LoginResponse["token"].ToString());
                            await SecureStorage.SetAsync("userRefreshToken", LoginResponse["refreshToken"].ToString());
                            await SecureStorage.SetAsync("userEmail", LoginResponse["email"].ToString());
                            await SecureStorage.SetAsync("userID", LoginResponse["id"].ToString());
                            await SecureStorage.SetAsync("AccountID", LoginResponse["accountId"].ToString());
                            await SecureStorage.SetAsync("ResourceID", LoginResponse["resourceId"].ToString());

                            //GetMainData(LoginResponse);

                            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
                            {
                                conn.CreateTable<LoginResponse>();
                                conn.InsertOrReplace(new LoginResponse() { userID = LoginResponse["accountId"].ToString(), userData = LoginResponse.ToString() });
                            };
                            #endregion

                            #region Check Patient exist Local or Not
                            //using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
                            //{
                            //    conn.CreateTable<Patient>();
                            //    var patient = conn.Table<Patient>().Where(v => v.PatientsGUID == loginUser.PatientsGuid).ToList().FirstOrDefault();

                            //    if (patient == null)
                            //    {
                            //        Patient p = new Patient()
                            //        {
                            //            PatientsGUID = loginUser.PatientsGuid,
                            //            PatientsName = loginUser.PatientsName,
                            //            PatientsEmail = loginUser.PatientsEmail,
                            //            PatientsPhone = loginUser.PatientsPhone,
                            //            PatientsLang = loginUser.PatientsLang
                            //        };
                            //        conn.Insert(p);
                            //    }
                            //};

                            #endregion

                            #region Check user exist Local or Not 

                            //using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
                            //{
                            //    conn.CreateTable<LoginUser>();
                            //    var user = conn.Table<LoginUser>().Where(v => v.PatientsGuid == loginUser.PatientsGuid).ToList().FirstOrDefault();

                            //    if (user == null)
                            //    {
                            //        loginUser.PatientsPassword = userLogin.password.ToString();
                            //        conn.Insert(loginUser);
                            //    }
                            //};
                            #endregion
                            App.Current.MainPage = new NavigationPage(new HomePage());
                            //intent = new Intent(webView.Context, typeof(HomeActivity));
                        }
                    }
                    break;
                case "gotohomepage":
                    App.Current.MainPage = new NavigationPage(new HomePage());
                    break;
                case "gotoregistration":
                    App.Current.MainPage.Navigation.PushAsync(new RegisterationPage());
                    break;

                case "doregister":
                    App.Current.MainPage.Navigation.PopAllPopupAsync();
                    //App.Current.MainPage.Navigation.PushAsync(new completeProfilePage());
                    //return;
                    if (string.IsNullOrEmpty(parameters["Password"]) && string.IsNullOrEmpty(parameters["ConfirmedPassword"]))
                    {
                        //Empty Data, show message to user
                        App.Current.MainPage.DisplayAlert("", AppResources.PasswordMismatch, "OK");

                    }
                    else
                    {
                        DoctorRegistrationModel RegisterUser = ConvertQueryString<DoctorRegistrationModel>(HttpUtility.ParseQueryString(strQueryParams));
                        //RegisterUser.Lang = Preferences.Get("savedLang", "en");
                        //RegisterUser.Country = "مصر";
                        //Preferences.Set("OTP", Registration.SecurityCode);
                        var Result = PostAPI("api/Authenticate/en-GB/Authenticate/register", JsonConvert.SerializeObject(RegisterUser));
                        if (string.IsNullOrEmpty(Result))
                        {
                            App.Current.MainPage.Navigation.PopAllPopupAsync();
                            return;
                        }
                        else
                        {
                            await SecureStorage.SetAsync("userConfirm", JObject.Parse(Result)["result"].ToString());
                            ConfirmEmailModel Registration = JsonConvert.DeserializeObject<ConfirmEmailModel>(Result);
                            App.Current.MainPage.Navigation.PushAsync(new OTPConfirmationPage(Registration));
                        }
                    }
                    break;

                case "dochangelanguage":
                    //Put logic here to earease secure storage and users table
                    var lang = parameters["lang"];

                    try
                    {
                        await Helper.LanguageService.SetLanguage(lang);
                        App.Refresh_Page();
                    }
                    catch (Exception ex)
                    {
                        App.Current.MainPage.Navigation.PopAllPopupAsync(true);
                    }
                    break;

                case "doconfirmation":
                    if (string.IsNullOrWhiteSpace(parameters["OTP"]))
                    {
                        App.Current.MainPage.Navigation.PopAllPopupAsync(true);
                        return;
                    }
                    else
                    {
                        if (Preferences.Get("forgetPassword", "") == "forgotpassword")
                        {
                            //Goto change password view
                            Preferences.Remove("forgetPassword");
                            await SecureStorage.SetAsync("UserName", parameters["PatientsEmail"]);
                            App.Current.MainPage.Navigation.PushAsync(new ChangePasswordPage());

                        }
                        else
                        {
                            //Register user, and if valid goto login page
                            //LoginUser RegiterUser = new LoginUser();
                            //RegiterUser.PatientsName = parameters["PatientsName"];
                            //RegiterUser.PatientsPhone = parameters["PatientsPhone"];
                            //RegiterUser.PatientsEmail = parameters["PatientsEmail"];
                            //RegiterUser.Password = parameters["Password"];
                            //RegiterUser.Country = parameters["Country"];
                            //RegiterUser.Lang = Preferences.Get("savedLang", "en");
                            var ConfirmUser = await SecureStorage.GetAsync("userConfirm");

                            var Result = PostAPI($"api/Authenticate/{Preferences.Get("savedCulture", "en-GB")}/Authenticate/confirmEmail/{parameters["OTP"]}", ConfirmUser);
                            if (string.IsNullOrEmpty(Result))
                            {
                                await App.Current.MainPage.Navigation.PopAllPopupAsync();
                                return;
                            }
                            Patient patient = JsonConvert.DeserializeObject<Patient>(Result);

                            if (patient == null)
                            {
                                //Invalid OTP confirmation, show message to user
                                ShowMessage(sender as WebView, AppResources.OTPConfirmFailure);
                            }
                            else
                            {
                                //add Patient To Local Storage
                                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
                                {
                                    //conn.CreateTable<Patient>();
                                    //conn.Insert(patient);
                                };
                                //delete shared Prefrences
                                Preferences.Set("CompleteRegistration", true);
                                if (Device.RuntimePlatform == "iOS")
                                    App.Current.MainPage = new NavigationPage(new LoginPage_iOS());
                                else
                                    App.Current.MainPage = new NavigationPage(new LoginPage());
                            }
                        }
                    }
                    break;
                case "gotootpback":
                    if (Preferences.Get("forgetPassword", "").ToLower() == "forgotpassword")
                    {
                        App.Current.MainPage.Navigation.PushAsync(new ForgotPasswordPage(string.Empty));
                    }
                    else
                    {
                        App.Current.MainPage.Navigation.PushAsync(new RegisterationPage());
                    }
                    break;

                case "doaddaddress":

                    break;

                case "gotomyprofile":
                    App.Current.MainPage.Navigation.PushAsync(new MyProfilePage());
                    break;
                case "doresendpassword":
                    LoginUser User = new LoginUser();
                    User.PatientsEmail = parameters["PatientsEmail"];
                    User.Lang = Preferences.Get("savedLang", "en");
                    if (string.IsNullOrWhiteSpace(parameters["PatientsEmail"]))
                    {
                        //Empty Data, show message to user
                        ShowMessage(sender as WebView, AppResources.FillAllRequiredFields);

                    }
                    else
                    {
                        var Result = PostAPI("ForgetPassword", JsonConvert.SerializeObject(User));
                        if (string.IsNullOrEmpty(Result))
                        {
                            await App.Current.MainPage.Navigation.PopAllPopupAsync();
                            return;
                        }
                        RegistrationVM Registration = JsonConvert.DeserializeObject<RegistrationVM>(Result);

                        if (!string.IsNullOrWhiteSpace(Registration.errorMessage))
                        {
                            //Invalid email, add it in temp variable, and show message to user
                            ShowMessage(sender as WebView, AppResources.validateEmail);

                        }
                        else
                        {
                            ShowMessage(sender as WebView, AppResources.OTPResent);
                            Preferences.Set("OTP", Registration.SecurityCode);

                        }
                    }
                    break;
                case "gotochangepassword":
                    App.Current.MainPage.Navigation.PushAsync(new ChangePasswordPage());
                    break;
                case "dochangepassword":
                    // App.Current.MainPage.Navigation.PushAsync(new NavigationPage(new ChangePasswordPage()));
                    if (string.IsNullOrWhiteSpace(parameters["NewPassword"]) || string.IsNullOrWhiteSpace(parameters["ConfirmedPassword"]))
                    {
                        //Empty Data, show message to user
                        ShowMessage(sender as WebView, AppResources.FillAllRequiredFields);
                        // intent = new Intent(webView.Context, typeof(ChangePasswordActivity));
                    }
                    else if (parameters["NewPassword"] != parameters["ConfirmedPassword"])
                    {
                        //Passwords don't match
                        ShowMessage(sender as WebView, AppResources.PasswordMismatch);
                    }
                    else
                    {
                        ResetPasswordVM userpassword = new ResetPasswordVM();
                        userpassword.password = parameters["NewPassword"];
                        userpassword.confirmPassword = parameters["ConfirmedPassword"];
                        userpassword.email = Preferences.Get("ForgotPasswordEmail", null);
                        userpassword.token = await SecureStorage.GetAsync("userToken");

                        var Result = PostAPI($"api/Authenticate/{Preferences.Get("savedCulture", "en-GB")}/Authenticate/resetPassword", JsonConvert.SerializeObject(userpassword));
                        if (string.IsNullOrEmpty(Result))
                        {
                            await App.Current.MainPage.Navigation.PopAllPopupAsync();
                            return;
                        }
                        if (Result.ToLower().Contains("PasswordChangeError"))
                        {
                            //Change password failed
                            ShowMessage(sender as WebView, AppResources.ChangePasswordFailed);

                        }
                        else
                        {
                            //Password changes successfully, goto login view
                            if (Device.RuntimePlatform == "iOS")
                                App.Current.MainPage = new NavigationPage(new LoginPage_iOS());
                            else
                                App.Current.MainPage = new NavigationPage(new LoginPage());
                        }
                    }

                    break;
                case "gotodoctordetails":
                    break;
                case "gotodoctordetailssearchresults":
                    break;
                case "gotodoctordetailsmybookings":
                    break;
                case "gotodoctordetailsmyfavorite":
                    break;
                case "gotoforgotpassword":
                    App.Current.MainPage.Navigation.PushAsync(new ForgotPasswordPage(parameters["email"].ToString()));
                    break;
                case "doforgetpassword":
                    if (string.IsNullOrWhiteSpace(parameters["Email"]))
                    {
                        //Empty Data, show message to user
                        ShowMessage(sender as WebView, AppResources.FillAllRequiredFields);
                    }
                    else
                    {
                        var Result = PostAPI($"api/Authenticate/{Preferences.Get("savedCulture", "en-GB")}/Authenticate/forgetPassword", JsonConvert.SerializeObject(new { email = parameters["Email"] }));
                        if (string.IsNullOrEmpty(Result))
                        {
                            await App.Current.MainPage.Navigation.PopAllPopupAsync();
                            return;
                        }
                        RegistrationVM Registration = JsonConvert.DeserializeObject<RegistrationVM>(Result);

                        if (!string.IsNullOrWhiteSpace(Registration.errorMessage))
                        {
                            ShowMessage(sender as WebView, AppResources.validateEmail);
                        }
                        else
                        {
                            Preferences.Set("ForgotPasswordEmail", parameters["Email"]);
                            Preferences.Set("forgetPassword", "forgotpassword");
                            App.Current.MainPage.Navigation.PushAsync(new OTPConfirmationPage(new ConfirmEmailModel() { email = parameters["Email"] }));
                        }
                    }
                    break;
                case "gotohome":
                    App.Current.MainPage = new NavigationPage(new HomePage());
                    break;
                case "gotocompare":
                    App.Current.MainPage.Navigation.PushAsync(new compareSelectedPage());
                    break;

                case "doexit":
                    var platform = Preferences.Get("UserLogin", null);
                    if (platform != null)
                    {
                        if (platform == "Facebook")
                        {
                            Facebook_Logout();
                        }
                        else if (platform == "Google")
                        {
                            Google_Logout();
                        }
                    }

                    SecureStorage.RemoveAll();
                    Preferences.Remove("UserImage");

                    try
                    {
                        var cachePath = System.IO.Path.GetTempPath();

                        // If exist, delete the cache directory and everything in it recursivly
                        if (System.IO.Directory.Exists(cachePath))
                            System.IO.Directory.Delete(cachePath, true);

                        // If not exist, restore just the directory that was deleted
                        if (!System.IO.Directory.Exists(cachePath))
                            System.IO.Directory.CreateDirectory(cachePath);
                    }
                    catch (Exception)
                    {
                        App.Current.MainPage.Navigation.PopAllPopupAsync(true);
                    }
                    if (Device.RuntimePlatform == "iOS")
                        App.Current.MainPage = new NavigationPage(new LoginPage_iOS());
                    else
                        App.Current.MainPage = new NavigationPage(new LoginPage());
                    break;

                case "gotobasicinfo":
                    App.Current.MainPage.Navigation.PushAsync(new basicInfoPage());
                    break;

                case "gotovitalsigns":
                    App.Current.MainPage.Navigation.PushAsync(new vitalSignsPage());
                    break;

                case "addnewvital":
                    try
                    {
                        PatientsVital Vitals = new PatientsVital()
                        {
                            ID = Guid.NewGuid(),
                            PatientsVitalsAirOrOxygen = parameters["AirOxygen"],
                            PatientsVitalsBloodPressure = parameters["BloodPressure"],
                            PatientsVitalsConsciousness = parameters["Consciousness"],
                            PatientsVitalsPatientsID = App.PatientEMR.Id,
                            PatientsVitalsPulse = string.IsNullOrEmpty(parameters["Pulse"]) ? 0 : Convert.ToInt32(parameters["Pulse"]),
                            PatientsVitalsRR = string.IsNullOrEmpty(parameters["Respiration"]) ? 0 : Convert.ToInt32(parameters["Respiration"]),
                            PatientsVitalsSpO2 = string.IsNullOrEmpty(parameters["SpO2"]) ? 0 : Convert.ToInt32(parameters["SpO2"]),
                            PatientsVitalsTemprature = string.IsNullOrEmpty(parameters["Temperature"]) ? 0 : Convert.ToInt32(parameters["Temperature"])
                        };
                        var Result = Shared.PostAPI($"api/Paitent/{Preferences.Get("savedCulture", "en-GB")}/EMR/savevital", JsonConvert.SerializeObject(Vitals));
                    }
                    catch (Exception ex)
                    { }
                    App.Refresh_Page();
                    break;
                case "gotogallery":
                    App.Current.MainPage.Navigation.PushAsync(new galleryPage());
                    break;

                case "dosaveprofiledata":

                    App.DoctorProfile.ResourcesName = parameters["DoctorName"];
                    App.DoctorProfile.ResourcesStaff.ResourcesGender = parameters["DoctorGender"];
                    App.DoctorProfile.ResourcesStaff.ResourcesDob = DateTimeOffset.Parse(parameters["DoctorDOB"]);
                    App.DoctorProfile.ResourcesStaff.ResourcesPhone1 = parameters["DoctorPhone"];
                    App.DoctorProfile.ResourcesStaff.ResourcesSpecialtiesId = Guid.Parse(parameters["DoctorSpecialty"]);
                    App.StaffProfile.ResourcesCareerLevel = parameters["DoctorDegree"];

                    Shared.PostAPI($"api/HR/{Preferences.Get("savedCulture", "en-GB")}/StaffSetting/saveStaffSetting", JsonConvert.SerializeObject(App.DoctorProfile));
                    Shared.PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/Staff/saveStaff", JsonConvert.SerializeObject(App.StaffProfile));
                    App.Refresh_Page();
                    break;

                case "douploadprofileimage":
                    var Imagefile = await FilePicker.PickAsync(new PickOptions() { FileTypes = FilePickerFileType.Images });

                    if (Imagefile == null)
                    {
                        await App.Current.MainPage.Navigation.PopAllPopupAsync();
                        return;
                    }
                    var fileStream = await Imagefile.OpenReadAsync();

                    //var ImageBase64 = streamToBase64(fileStream);
                    //var FullBase64 = $"data:{Imagefile.ContentType};base64,{ImageBase64}";

                    //Preferences.Set("UserImage", FullBase64);
                    //FileDetails FD = new FileDetails() { ContentBase64 = FullBase64, GUID = await SecureStorage.GetAsync("PatientsGuid") };

                    if (IsConnected())
                    {

                        var handler = new HttpClientHandler();
                        HttpClient client = new HttpClient(handler);
                        client.BaseAddress = new Uri(baseUrl);

                        APIs.HR.StaffSettingClient HRclient = new APIs.HR.StaffSettingClient(client);

                        var ImageResult = HRclient.EditStaffImageAsync(Guid.Parse(SecureStorage.GetAsync("ResourceID").Result), new APIs.HR.FileParameter(fileStream), Preferences.Get("savedCulture", "en-GB")).Result;
                    }
                    else
                    {
                        Preferences.Set("SyncProfile", true);
                    }

                    App.Refresh_Page();
                    break;


                case "douploadfiles":
                    var files = await FilePicker.PickMultipleAsync();
                    if (files == null || files.Count() < 1)
                    {
                        App.Current.MainPage.Navigation.PopAllPopupAsync();
                        return;
                    }
                    var ImageDict = new Dictionary<byte[], string>();

                    foreach (var file in files)
                    {
                        var stream = await file.OpenReadAsync();
                        var FileBase64 = streamToBase64(stream);
                        var ImageArray = ConvertBase64ToByteArray(FileBase64);
                        ImageDict.Add(ImageArray, file.FileName);
                    }

                    var SaveAttachmentdict = new Dictionary<string, string>();
                    SaveAttachmentdict.Add("ParentID", App.PatientEMR.Id);
                    SaveAttachmentdict.Add("AccountsID", SecureStorage.GetAsync("AccountID").Result);
                    SaveAttachmentdict.Add("Type", "Patient");
                    SaveAttachmentdict.Add("WorkFlowRef", null);

                    var SaveAttachment = PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/Account/SaveAttachment", null, false, "POST", SaveAttachmentdict, ImageDict);

                    App.Refresh_Page();
                    break;

                case "douploadexamfiles":
                    var examfiles = await FilePicker.PickMultipleAsync();
                    if (examfiles == null || examfiles.Count() < 1)
                    {
                        App.Current.MainPage.Navigation.PopAllPopupAsync();
                        return;
                    }
                    var ExamImageDict = new Dictionary<byte[], string>();

                    foreach (var file in examfiles)
                    {
                        var stream = await file.OpenReadAsync();
                        var FileBase64 = streamToBase64(stream);
                        var ImageArray = ConvertBase64ToByteArray(FileBase64);
                        ExamImageDict.Add(ImageArray, file.FileName);
                    }

                    var ExamSaveAttachmentdict = new Dictionary<string, string>();
                    ExamSaveAttachmentdict.Add("ParentID", parameters["ParentID"]);
                    ExamSaveAttachmentdict.Add("AccountsID", SecureStorage.GetAsync("AccountID").Result);
                    ExamSaveAttachmentdict.Add("Type", "Examination");
                    ExamSaveAttachmentdict.Add("WorkFlowRef", null);

                    var ExamSaveAttachment = PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/Account/SaveAttachment", null, false, "POST", ExamSaveAttachmentdict, ExamImageDict);

                    App.Refresh_Page(parameters["ParentID"]);
                    break;

                case "deletefiles":
                    if (await App.Current.MainPage.DisplayAlert("", "Are you sure to delete this file?", "OK", "Cancel"))
                    {
                        var Result = Shared.PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/Account/api/DeleteFile?ID={parameters["FileID"]}&AccountsID={SecureStorage.GetAsync("AccountID")}&ParentID={App.PatientEMR.Id}&Type=Patient", "{}");
                        App.Refresh_Page();
                    }
                    break;

                case "deleteexamfiles":
                    if (await App.Current.MainPage.DisplayAlert("", "Are you sure to delete this file?", "OK", "Cancel"))
                    {
                        var Result = Shared.PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/Account/api/DeleteFile?ID={parameters["FileID"]}&AccountsID={SecureStorage.GetAsync("AccountID")}&ParentID={parameters["ParentID"]}&Type=Examination", "{}");
                        App.Refresh_Page(parameters["ParentID"]);
                    }
                    break;

                case "dodownloadattachment":
                    break;

                case "gotosearchpatients":
                    int page = 1;
                    int.TryParse(parameters["SearchPage"], out page);
                    App.Current.MainPage.Navigation.PushAsync(new patientsPage(page));
                    break;
                case "gotosearchname":
                    App.Current.MainPage.Navigation.PushAsync(new SearchNamePage());
                    break;
                case "gotopatientsemr":
                    App.PatientID = parameters["PatientID"];

                    var PatientEmrData = PostAPI($"api/Paitent/{Preferences.Get("savedCulture", "en-GB")}/PatientsEmr/getPatientEMR/{parameters["PatientID"]}", null, false, "GET");
                    if (string.IsNullOrWhiteSpace(PatientEmrData))
                        PatientEmrData = Preferences.Get(App.PatientID, "","PatientData");
                    else
                        Preferences.Set(App.PatientID, PatientEmrData, "PatientData");

                    if (!string.IsNullOrWhiteSpace(PatientEmrData))
                    {
                        App.PatientEMR = JsonConvert.DeserializeObject<Helper.EMR.PatientVM>(JObject.Parse(PatientEmrData)["result"].ToString());
                        App.Current.MainPage.Navigation.PushAsync(new patientsEMRPage());
                    }
                    else
                        App.Current.MainPage.DisplayAlert("", "EMR Data not available for this patient!", "OK");

                    break;
                case "gotopatientsemrfrombooking":
                    try
                    {
                        App.PatientID = parameters["PatientID"];

                        var PatientIDData = PostAPI($"api/Paitent/{Preferences.Get("savedCulture", "en-GB")}/Paitent/getPatientId?vId={parameters["PatientID"]}", null, false, "GET");

                        if (!string.IsNullOrWhiteSpace(PatientIDData))
                        {
                            var response = JsonConvert.DeserializeObject<ResponseOfVisitsOrderModevm>(PatientIDData.ToString()).Result as VisitsOrderModevm;
                            var PatientID = response.Patientid;

                            var PatientEmrDataFromBooking = PostAPI($"api/Paitent/{Preferences.Get("savedCulture", "en-GB")}/PatientsEmr/getPatientEMR/{PatientID.ToString()}", null, false, "GET");

                            Preferences.Set(App.PatientID, PatientEmrDataFromBooking, "PatientData");

                            App.PatientEMR = new PatientVM();
                            App.PatientEMR = JsonConvert.DeserializeObject<Helper.EMR.PatientVM>(JObject.Parse(PatientEmrDataFromBooking)["result"].ToString());
                        }
                        else
                        {
                            try
                            {
                                App.PatientEMR = new PatientVM();
                                App.PatientID = Preferences.Get(parameters["PatientID"],"");
                                App.PatientEMR = JsonConvert.DeserializeObject<Helper.EMR.PatientVM>(JObject.Parse(Preferences.Get(App.PatientID, "","PatientData"))["result"].ToString());
                                if (App.PatientEMR.PatientsEMR == null)
                                    App.PatientEMR.PatientsEMR = new PatientsEmr();
                            }
                            catch
                            {
                                App.Current.MainPage.DisplayAlert("", "EMR Data is not available for this patient!", "OK");
                            }
                        }

                        if (App.PatientEMR != null)
                            App.Current.MainPage.Navigation.PushAsync(new patientsEMRPage());
                        else
                            App.Current.MainPage.DisplayAlert("", "EMR Data is not available for this patient!", "OK");
                    }
                    catch(Exception ex)
                    { }
                    break;

                case "savepatientemr":

                    if (App.PatientEMR.PatientsEMR == null)
                    {
                        App.PatientEMR.PatientsEMR = new PatientsEmr() { Id = App.PatientEMR.Id };
                    }


                    if (parameters["profile"] != null)
                    {
                        App.PatientEMR.PatientsName = parameters["PatientName"];
                        App.PatientEMR.PatientsNationality = parameters["PatientNationality"];
                        App.PatientEMR.PatientsNationalID = parameters["PatientNationalityID"];
                        App.PatientEMR.PatientsDOB = parameters["PatientDOB"];
                        App.PatientEMR.PatientsGender = parameters["PatientGender"];
                        App.PatientEMR.PatientsMobile = parameters["PatientMobile"];
                        App.PatientEMR.PatientsPhone = parameters["PatientPhone"];
                        App.PatientEMR.PatientsEmail = parameters["PatientEmail"];
                        App.PatientEMR.PatientsStreet = parameters["PatientAddress"];
                    }
                    else
                    {
                        App.PatientEMR.PatientsEMR.PatientsRiskFactors = parameters["RiskFactors"].Replace(',', '|');
                        App.PatientEMR.PatientsEMR.PatientsChronicDisease = parameters["ChronicDiseases"].Replace(',', '|');
                        App.PatientEMR.PatientsEMR.PatientsClaustrophobic = parameters["Phobias"].Replace(',', '|');
                        App.PatientEMR.PatientsEMR.PatientsMedicalHistory = parameters["PatientsMedicalHistory"];
                        App.PatientEMR.PatientsEMR.PatientsImplants = parameters["Implants"];
                        App.PatientEMR.PatientsEMR.PatientsSocialHabits = parameters["SocialHabits"].Replace(',', '|');
                        App.PatientEMR.PatientsEMR.PatientsSocialNotes = parameters["SocialNotes"];
                        App.PatientEMR.PatientsEMR.PatientsSurgeryHistory = parameters["SurgeryNotes"];
                        App.PatientEMR.PatientsEMR.PatientsHowMany = parameters["Alcohol"];
                        App.PatientEMR.PatientsEMR.PatientsPerCoffee = parameters["Coffee"];
                        App.PatientEMR.PatientsEMR.PatientsPerTea = parameters["Tea"];
                        App.PatientEMR.PatientsEMR.PatientsSmoker = parameters["Smoker"];
                        App.PatientEMR.PatientsEMR.PatientsIsRecreationalDrugsDetails = parameters["RecreationalDrugs"];
                        App.PatientEMR.PatientsEMR.PatientsOccupationalHazardsDetails = parameters["OccupationalHazards"];
                        App.PatientEMR.PatientReviewSystemsItems = parameters["ReviewOptions"].Split(',').ToList();
                    }

                    App.PatientEMR.PatientsEMR.IdNavigation = null;

                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    dict.Add("PatientVM", JsonConvert.SerializeObject(App.PatientEMR));

                    var result = PostAPI($"api/Paitent/{Preferences.Get("savedCulture", "en-GB")}/PatientsEmr/savePatientsEmr", null, false, "POST", dict);


                    App.Refresh_Page();
                    break;
                case "savebasicinfo":

                    break;
                case "gotonewexamination":
                    App.Current.MainPage.Navigation.PushAsync(new ExaminationPage(parameters["ExamID"]));
                    break;
                #region Add New Examination
                case "addeditexamination":
                    var par = HttpUtility.ParseQueryString(strQueryParams);
                    Dictionary<string, object> ReturnedData = par.AllKeys.ToDictionary(k => k, k => (object)par[k]);
                    List<ExaminationsDatum> ExaminationsDatums = new List<ExaminationsDatum>();

                    try
                    {

                        var h = (from val in ReturnedData
                                 group val by val.Key.Substring(0, val.Key.IndexOf(".") + 1) into item
                                 select item).ToList();

                        foreach (var exam in h)
                        {
                            Dictionary<string, object> xx = exam.ToDictionary(g => g.Key, g => g.Value);
                            var exam1 = Converter.DictionaryToObject(xx, exam.Key);
                            var exam2 = Converter.DynamicToObject<ExaminationsDatum>(exam1);
                            ExaminationsDatums.Add(exam2);
                        }

                    }
                    catch (Exception ex)
                    {
                        string msg = ex.Message;

                    }
                    if (string.IsNullOrWhiteSpace(parameters["examID"]))
                    {
                        Examination NewExam = new Examination();
                        NewExam.Id = Guid.NewGuid().ToString();
                        NewExam.ExaminationPatientsId = App.PatientEMR.PatientsEMR.Id;
                        NewExam.ExaminationResourcesId = await SecureStorage.GetAsync("ResourceID");
                        //NewExam.ExaminationDiagnosis = string.IsNullOrEmpty(parameters["Diagnosis"]) ? "" : parameters["Diagnosis"].Replace(',', '|');
                        //NewExam.ExaminationsData = ExaminationsDatums;
                        NewExam.PatientsVital = new PatientsVital();
                        NewExam.PatientsVital.ID = Guid.NewGuid();
                        NewExam.PatientsVital.PatientsVitalsPatientsID = App.PatientEMR.PatientsEMR.Id;
                        var invsjson = parameters["invs"];
                        if (!string.IsNullOrWhiteSpace(parameters["invs"]))
                        {
                            var invsarray = JArray.Parse(parameters["invs"]);
                            NewExam.ExaminationInvestigations = new List<ExaminationInvestigation>();
                            foreach (var inv in invsarray)
                            {
                                var obj = JObject.Parse(inv.ToString());
                                NewExam.ExaminationInvestigations = new List<ExaminationInvestigation>();
                                NewExam.ExaminationInvestigations.Add(new ExaminationInvestigation()
                                {
                                    ExaminationInvestigationsName = obj["invname"].ToString(),
                                    ExaminationInvestigationsType = obj["invtype"].ToString(),
                                    ExaminationInvestigationsNotes = obj["invnotes"].ToString()
                                });
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(parameters["treatments"]))
                        {
                            var treatmentsarray = JArray.Parse(parameters["treatments"]);
                            NewExam.ExaminationTreatments = new List<ExaminationTreatment>();
                            foreach (var treatment in treatmentsarray)
                            {
                                var obj = JObject.Parse(treatment.ToString());
                                if (NewExam.ExaminationTreatments == null)
                                    NewExam.ExaminationTreatments = new List<ExaminationTreatment>();
                                NewExam.ExaminationTreatments.Add(new ExaminationTreatment()
                                {
                                    ExaminationTreatmentsDrugName = obj["treatmentname"].ToString(),
                                    ExaminationTreatmentsConcentration = obj["treatmentconcentration"].ToString(),
                                    ExaminationTreatmentsForm = obj["treatmentform"].ToString(),
                                    ExaminationTreatmentsRoute = obj["treatmentroute"].ToString(),
                                    ExaminationTreatmentsDosage = obj["treatmentdosage"].ToString(),
                                    ExaminationTreatmentsUnit = obj["treatmentunit"].ToString(),
                                    ExaminationTreatmentsFrequency = obj["treatmenthours"].ToString(),
                                    ExaminationTreatmentsDuration = obj["treatmentdays"].ToString(),
                                    ExaminationTreatmentsNotes = obj["treatmentnotes"].ToString()

                                });
                            }
                        }
                        result = PostAPI($"api/Paitent/{Preferences.Get("savedCulture", "en-GB")}/EMR/savefullexamination", JsonConvert.SerializeObject(NewExam));
                        await App.Current.MainPage.Navigation.PopAsync();
                        App.Refresh_Page();
                    }
                    else
                    {
                        result = PostAPI($"api/Paitent/{Preferences.Get("savedCulture", "en-GB")}/EMR/getfullexamination?id=" + parameters["examID"], JsonConvert.SerializeObject(new { id = parameters["examID"] }));

                        var treatments = PostAPI($"api/Paitent/{Preferences.Get("savedCulture", "en-GB")}/EMR/loadtreatments?id=" + parameters["examID"], JsonConvert.SerializeObject(new { id = parameters["examID"] }));

                        var myExam = JsonConvert.DeserializeObject<Examination>(JObject.Parse(result)["result"].ToString());
                        var myTreatments = JsonConvert.DeserializeObject<List<ExaminationTreatment>>(JObject.Parse(treatments)["result"].ToString());

                        var invsjson = parameters["invs"];
                        if (!string.IsNullOrWhiteSpace(parameters["invs"]))
                        {
                            var invsarray = JArray.Parse(parameters["invs"]);
                            foreach (var inv in invsarray)
                            {
                                var obj = JObject.Parse(inv.ToString());
                                myExam.ExaminationInvestigations.Add(new ExaminationInvestigation()
                                {
                                    Id = Guid.Parse(obj["invid"].ToString()),
                                    ExaminationInvestigationsName = obj["invname"].ToString(),
                                    ExaminationInvestigationsType = obj["invtype"].ToString(),
                                    ExaminationInvestigationsNotes = obj["invnotes"].ToString()
                                });
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(parameters["treatments"]))
                        {
                            var treatmentsarray = JArray.Parse(parameters["treatments"]);
                            foreach (var treatment in treatmentsarray)
                            {
                                var obj = JObject.Parse(treatment.ToString());
                                if (myTreatments == null)
                                    myExam.ExaminationTreatments = new List<ExaminationTreatment>();
                                myTreatments.Add(new ExaminationTreatment()
                                {
                                    ExaminationTreatmentsAccountsId = Guid.Parse(SecureStorage.GetAsync("AccountID").Result),
                                    ExaminationTreatmentsExaminationId = myTreatments[0].ExaminationTreatmentsExaminationId,
                                    ExaminationTreatmentsDrugName = obj["treatmentname"].ToString(),
                                    ExaminationTreatmentsConcentration = obj["treatmentconcentration"].ToString(),
                                    ExaminationTreatmentsForm = obj["treatmentform"].ToString(),
                                    ExaminationTreatmentsRoute = obj["treatmentroute"].ToString(),
                                    ExaminationTreatmentsDosage = obj["treatmentdosage"].ToString(),
                                    ExaminationTreatmentsUnit = obj["treatmentunit"].ToString(),
                                    ExaminationTreatmentsFrequency = obj["treatmenthours"].ToString(),
                                    ExaminationTreatmentsDuration = obj["treatmentdays"].ToString(),
                                    ExaminationTreatmentsNotes = obj["treatmentnotes"].ToString()

                                });
                            }
                            if (myExam.PatientsVital == null)
                                myExam.PatientsVital = new PatientsVital() { PatientsVitalsPatientsID = App.PatientEMR.PatientsEMR.Id };
                            myExam.ExaminationTreatments = myTreatments;
                        }
                        result = PostAPI($"api/Paitent/{Preferences.Get("savedCulture", "en-GB")}/EMR/savefullexamination", JsonConvert.SerializeObject(myExam));
                        App.Refresh_Page(parameters["examID"]);
                    }
                    //NewExam.ExaminationInvestigations = new List<ExaminationInvestigation>();
                    //NewExam.ExaminationInvestigations.Add(new ExaminationInvestigation() { });

                    //NewExam.ExaminationTreatments = new List<ExaminationTreatment>();
                    //NewExam.ExaminationTreatments.Add(new ExaminationTreatment() { });



                    

                    break;
                #endregion

                case "saveschedules":
                    List<string> DaysSaved = new List<string>();
                    foreach (var weekday in Enum.GetNames(typeof(Weekdays)))
                    {
                        List<string> CommonDays = new List<string>();
                        if (DaysSaved.Contains(weekday))
                            continue;
                        if (string.IsNullOrWhiteSpace(parameters[$"{weekday}_From"]) && string.IsNullOrWhiteSpace(parameters[$"{weekday}_To"]))
                            continue;
                        foreach (var weekday2 in Enum.GetNames(typeof(Weekdays)))
                        {
                            if (parameters[$"{weekday}_From"] == parameters[$"{weekday2}_From"] && parameters[$"{weekday}_To"] == parameters[$"{weekday2}_To"])
                            {
                                CommonDays.Add(weekday2);
                                DaysSaved.Add(weekday2);
                            }
                        }
                        APIs.Account.Schedule Scheduleobj = new APIs.Account.Schedule();
                        Scheduleobj.SchedulesAccountsId = Guid.Parse(SecureStorage.GetAsync("AccountID").Result);
                        Scheduleobj.SchedulesResourcesId = Guid.Parse(SecureStorage.GetAsync("ResourceID").Result);
                        Scheduleobj.SchedulesLocationsId = Guid.Parse("0012fdcd-4367-4053-8c77-d4fd5fe127fe");
                        Scheduleobj.SchedulesType = "Recurring";
                        Scheduleobj.SchedulesActive = true;
                        Scheduleobj.SchedulesMode = "Interval";
                        Scheduleobj.SchedulesStartDate = DateTime.Now;
                        Scheduleobj.SchedulesEndDate = null;
                        Scheduleobj.SchedulesFreuencyOccurs = "Week";
                        Scheduleobj.SchedulesFreuencyOccursEvery = 1;
                        Scheduleobj.SchedulesStartTime = parameters[$"{weekday}_From"];
                        Scheduleobj.SchedulesEndTime = parameters[$"{weekday}_To"];
                        Scheduleobj.SchedulesFreuencyOccursWeekdays = (CommonDays.Count > 0) ? String.Join("|", CommonDays) : weekday;
                        result = PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/Schedule/saveSchedule", JsonConvert.SerializeObject(Scheduleobj));
                    }
                    App.Refresh_Page();
                    break;
                case "editschedules":
                    APIs.Account.Schedule ScheduleEdit = new APIs.Account.Schedule();
                    ScheduleEdit.Id = Guid.Parse(parameters["Selected_ScheduleID"]);
                    ScheduleEdit.SchedulesAccountsId = Guid.Parse(SecureStorage.GetAsync("AccountID").Result);
                    ScheduleEdit.SchedulesResourcesId = Guid.Parse(SecureStorage.GetAsync("ResourceID").Result);
                    //ScheduleEdit.SchedulesLocationsId = Guid.Parse(parameters["Selected_Location"]);
                    ScheduleEdit.SchedulesType = "Recurring";
                    ScheduleEdit.SchedulesActive = true;
                    ScheduleEdit.SchedulesMode = "Day";
                    ScheduleEdit.SchedulesMaxVisits = 0;
                    ScheduleEdit.SchedulesStartDate = DateTime.Now;
                    ScheduleEdit.SchedulesEndDate = null;
                    ScheduleEdit.SchedulesFreuencyOccurs = "Week";
                    ScheduleEdit.SchedulesFreuencyOccursEvery = 1;
                    ScheduleEdit.SchedulesStartTime = parameters["Input_From"];
                    ScheduleEdit.SchedulesEndTime = parameters["Input_To"];
                    ScheduleEdit.SchedulesFreuencyOccursWeekdays = parameters["Selected_Days"].Replace(',', '|');
                    result = PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/Schedule/saveSchedule", JsonConvert.SerializeObject(ScheduleEdit));
                    App.Refresh_Page();
                    break;
                case "addlocation":
                    EDSDoctorsApp.APIs.Account.Location NewLocation = new APIs.Account.Location() { LocationsName = parameters["LocationName"], LocationsAccountsId = Guid.Parse(SecureStorage.GetAsync("AccountID").Result), Id = string.IsNullOrEmpty(parameters["LocationID"]) ? null : parameters["LocationID"] };
                    result = PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/Location/saveLocation", JsonConvert.SerializeObject(NewLocation));
                    App.Refresh_Page();
                    break;
                case "deletelocation":
                    result = await DeleteMainData(new List<string>() { parameters["LocationID"] }, "Locations", "Locations");
                    App.Refresh_Page();
                    break;
                case "deleteschedule":
                    result = await DeleteMainData(new List<string>() { parameters["ScheduleID"] }, "Schedules", "Schedules");
                    App.Refresh_Page();
                    break;
                case "deleteinvestigation":

                    break;
                case "gotosearchspecialty":
                    break;

                case "gotosearchresults":
                    break;

                case "gotosearchresultsname":
                    break;

                case "gotosearchresultsspecialty":
                    break;

                case "gotomybookings":
                    int bookingpage = 1;
                    int.TryParse(parameters["BookingPage"], out bookingpage);
                    App.Current.MainPage.Navigation.PushAsync(new bookingPage(bookingpage));
                    break;

                case "gotomyfavorites":
                    break;

                case "dosortbooking":
                    App.Current.MainPage.Navigation.PushAsync(new bookingPage(0, parameters["sortby"], parameters["sort"]));
                    break;
                case "dosortpatients":
                    App.Current.MainPage.Navigation.PushAsync(new patientsPage(0, parameters["sortby"], parameters["sort"]));
                    break;
                case "dofiltercareer":
                    break;
                case "dofiltergender":
                    break;

                case "docancel":
                    break;

                case "dosavebooking":
                    break;

                case "gotovisitdetails":
                    break;
                case "gotodoctorchats":
                    break;
                case "goback":
                    App.Current.MainPage.Navigation.PopAsync();
                    break;
                default:
                    break;
            }
            try
            {
                App.Current.MainPage.Navigation.PopAllPopupAsync(true);
            }
            catch
            { }
        }

        public enum Weekdays
        {
            Saturday = 0,
            Sunday = 1,
            Monday = 2,
            Tuesday = 3,
            Wednesday = 4,
            Thursday = 5,
            Friday = 6
        }

        public static string baseUrl = "https://api.edoctorgroup.com";
        public static bool IsConnected()
        {
            var Status = Connectivity.NetworkAccess.ToString();
            if (Status != "Internet")
            {
                return false;
            }
            else
                return true;
        }

        public static string PostAPI(string strMethod, string strContent = null, bool bIgnoreToken = false, string Method = "POST", Dictionary<string, string> Dict = null, Dictionary<byte[], string> Images = null)
        {
            try
            {
                App.Current.MainPage.Navigation.PushPopupAsync(new LoaderPage());
            }
            catch
            { }
            if (bIgnoreToken || UpdateToken())
            {
                var handler = new HttpClientHandler();
                HttpClient client = new HttpClient(handler);
                client.BaseAddress = new Uri(baseUrl);

                if (!bIgnoreToken)
                {
                    var token = SecureStorage.GetAsync("userToken").Result;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                try
                {
                    if (Dict != null)
                    {
                        var multipartContent = new MultipartFormDataContent();
                        foreach (var item in Dict)
                        {
                            multipartContent.Add(new StringContent(item.Value == null ? "" : item.Value), item.Key);
                        }
                        if (Images != null)
                        {
                            foreach (var image in Images)
                            {
                                var byteArrayContent = new ByteArrayContent(image.Key);
                                byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                                multipartContent.Add(byteArrayContent, name:"file", fileName: image.Value);
                            }
                        }
                        using HttpResponseMessage response = client.PostAsync(strMethod, multipartContent).Result;
                        response.EnsureSuccessStatusCode();
                        return response.Content.ReadAsStringAsync().Result;
                    }
                    var content = strContent == null ? new StringContent("") : new StringContent(strContent, Encoding.UTF8, "application/json");
                    HttpRequestMessage HttpMessage = new HttpRequestMessage(new HttpMethod(Method), strMethod) { Content = content };
                    var HttpResponse = client.SendAsync(HttpMessage).Result;
                    if (HttpResponse.IsSuccessStatusCode)
                    {
                        try
                        {
                            App.Current.MainPage.Navigation.PopAllPopupAsync();
                        }
                        catch
                        { }
                        var res = HttpResponse.Content;
                        return res.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        //var X =  HttpResponse.Content.ReadAsStringAsync().Result;
                        //var X =  HttpResponse.Content.ReadAsStringAsync();
                        //var xx = X.ReadAsStringAsync().Result;
                        throw new System.ArgumentException("Error in " + strMethod + " " + HttpResponse.StatusCode + " " + HttpResponse.Content.ReadAsStringAsync());
                        Application.Current.MainPage.DisplayAlert("Error", "Failed to reach the server, please check your internet connection", "OK");
                    }
                }
                catch (Exception ex)
                {
                    string Error = ex.Message;
                    Debug.WriteLine(Error, "Error");
                    try
                    {
                        Application.Current.MainPage.Navigation.PopAllPopupAsync();
                    }
                    catch
                    { }
                    return null;
                }
            }
            else
            {
                //App.Current.MainPage.DisplayAlert("Error", "Error contacting server, please try again later!", "OK");
                return null;
                //throw new System.ArgumentException("No Valid Token For " + strMethod);
            }
        }

        public static string GetAPI(string strMothod, bool bIgnoreToken = false)
        {
            if (bIgnoreToken)
            {
                var handler = new HttpClientHandler();
                HttpClient client = new HttpClient(handler);
                client.BaseAddress = new Uri(baseUrl);

                //if (!bIgnoreToken) client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _GatewayToken.token);

                var HttpResponse = client.GetAsync(strMothod).Result;
                if (HttpResponse.IsSuccessStatusCode)
                {
                    var res = HttpResponse.Content;
                    return res.ReadAsStringAsync().Result;
                }
                else
                {
                    throw new System.ArgumentException("Get API Error For " + strMothod);
                }
            }
            else
            {
                throw new System.ArgumentException("No Valid Token For " + strMothod);
            }
        }

        //public static async Task<string> GetToken()
        //{
        //    var handler = new HttpClientHandler();
        //    HttpClient client = new HttpClient(handler);
        //    client.BaseAddress = new Uri(baseUrl);
        //    UserLogin validateUser = new UserLogin() { portalEmail = "edoctor@gmail.com", portalPassword = "12345678" };
        //    string strContent = JsonConvert.SerializeObject(validateUser);

        //    var content = new StringContent(strContent, Encoding.UTF8, "application/json");
        //    var HttpResponse = await client.PostAsync($"api/Authenticate/{Preferences.Get("savedCulture","en-GB")}/Authenticate/login/false", content);
        //    if (HttpResponse.IsSuccessStatusCode)
        //    {
        //        App.Current.MainPage.Navigation.PopAllPopupAsync();
        //        var res = HttpResponse.Content.ReadAsStringAsync().Result;
        //        var Token = JObject.Parse(res)["result"]["token"].ToString();
        //        var refreshToken = JObject.Parse(res)["result"]["refreshToken"].ToString();
        //        await SecureStorage.SetAsync("userToken", Token);
        //        await SecureStorage.SetAsync("userRefreshToken", refreshToken);
        //        return Token;
        //    }
        //    return null;
        //}

        public static bool UpdateToken()
        {
            //TokenModel tokens = new TokenModel()
            //{
            //    accessToken = await SecureStorage.GetAsync("userToken"),
            //    refreshToken = await SecureStorage.GetAsync("userRefreshToken")
            //};

            //var payload = JsonConvert.SerializeObject(tokens);

            //var Result = await Shared.PostAPI($"api/Authenticate/{Preferences.Get("SavedCulture", "en-GB")}/Authenticate/refresh", payload, false);

            //var token = Result;

            //if (_GatewayToken == null || _GatewayToken.expiration < DateTime.Now)
            if (true)
            {
                TokenModel _Token = new TokenModel()
                {
                    token = SecureStorage.GetAsync("userToken").Result,
                    refreshToken = SecureStorage.GetAsync("userRefreshToken").Result
                };

                if (string.IsNullOrEmpty(_Token.token))
                {
                    //GenerateToken();
                    return true;
                }
                else
                {
                    try
                    {
                        RefreshTokenModel Token = new RefreshTokenModel() { accessToken = _Token.token, refreshToken = _Token.refreshToken };
                        string responseString = PostAPI($"api/Authenticate/{Preferences.Get("savedCulture", "en-GB")}/Authenticate/refresh", JsonConvert.SerializeObject(Token), true);
                        //if (string.IsNullOrEmpty(responseString))
                        //    GenerateToken();
                        //else
                        {
                            _Token = JsonConvert.DeserializeObject<TokenModel>(JObject.Parse(responseString)["result"].ToString());
                            SecureStorage.SetAsync("userToken", _Token.token);
                            SecureStorage.SetAsync("userRefreshToken", _Token.refreshToken);
                        }
                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return true;
            }

        }

        public static void GenerateToken()
        {
            ValidateVM validate = new ValidateVM() { portalEmail = "himsdoctorsapp@eds.local", portalPassword = "3D$D0c@pp@cc3$$" };
            string responseString = PostAPI($"api/Authenticate/{Preferences.Get("savedCulture", "en-GB")}/Authenticate/Validate", JsonConvert.SerializeObject(validate), true);
            TokenModel _Token = JsonConvert.DeserializeObject<TokenModel>(JObject.Parse(responseString)["result"].ToString());
            SecureStorage.SetAsync("userToken", _Token.token);
            SecureStorage.SetAsync("userRefreshToken", _Token.refreshToken);
        }

        public class GatewayToken
        {
            public string token { get; set; }
            public DateTime expiration { get; set; }
        }

        public static string GetQueryStringValue(string strQuery, string strKey)
        {
            if (!string.IsNullOrWhiteSpace(strQuery))
            {
                return System.Web.HttpUtility.ParseQueryString(strQuery).Get(strKey);
            }
            else
            {
                return "";
            }

        }
        public static void ShowMessage(WebView view, string strMessage)
        {
            view.EvaluateJavaScriptAsync("javascript:showtoastr('" + strMessage + "');");
        }

        public static Task GetAllPatientEMR(string vID)
        {
            try
            {

                var PatientIDData = PostAPI($"api/Paitent/{Preferences.Get("savedCulture", "en-GB")}/Paitent/getPatientId?vId={vID}", null, false, "GET");

                if (!string.IsNullOrWhiteSpace(PatientIDData))
                {
                    var response = JsonConvert.DeserializeObject<ResponseOfVisitsOrderModevm>(PatientIDData.ToString()).Result as VisitsOrderModevm;
                    App.PatientID = response.Patientid.ToString();

                    var PatientEmrDataFromBooking = PostAPI($"api/Paitent/{Preferences.Get("savedCulture", "en-GB")}/PatientsEmr/getPatientEMR/{App.PatientID}", null, false, "GET");

                    Preferences.Set(vID, App.PatientID);
                    Preferences.Set(App.PatientID, PatientEmrDataFromBooking, "PatientData");

                    App.PatientEMR = new PatientVM();
                    App.PatientEMR = JsonConvert.DeserializeObject<Helper.EMR.PatientVM>(JObject.Parse(PatientEmrDataFromBooking)["result"].ToString());
                }
                else
                {
                    try
                    {
                        App.PatientEMR = new PatientVM();
                        App.PatientEMR = JsonConvert.DeserializeObject<Helper.EMR.PatientVM>(JObject.Parse(Preferences.Get(App.PatientID, "", "PatientData"))["result"].ToString());
                    }
                    catch
                    {
                        App.Current.MainPage.DisplayAlert("", "EMR Data is not available for this patient!", "OK");
                        return null;
                    }
                }

                if (App.PatientEMR == null)
                    App.Current.MainPage.DisplayAlert("", "EMR Data is not available for this patient!", "OK");
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static T ConvertQueryString<T>(NameValueCollection valueCollection)
        {
            var result = new ExpandoObject() as IDictionary<string, object>;
            foreach (var key in valueCollection.AllKeys)
            {
                result.Add(key, valueCollection[key]);
            }
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(result));
        }

        public static async void DoSync()
        {
            #region Syncing Profile Picture to Database
            try
            {
                FileDetails FD = new FileDetails() { ContentBase64 = Preferences.Get("UserImage", null), GUID = await SecureStorage.GetAsync("PatientsGuid") };
                var Result = PostAPI("ChangeProfilePicture", JsonConvert.SerializeObject(FD));
            }
            catch (Exception e)
            {
                Debug.WriteLine("Failed to Sync Profile Pic: " + e.Message);
            }
            #endregion
        }

        public static async void Apple_Auth(Uri uri)
        {
            SocialMediaLogin UserLogin = null;
            if (uri == null)
                return;
            uri = new Uri(uri.OriginalString.Replace("#", "&"));
            var idToken = HttpUtility.ParseQueryString(uri.PathAndQuery).Get("id_token");
            var userData = HttpUtility.ParseQueryString(uri.PathAndQuery).Get("user");

            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(idToken);

            string email = "";
            string userID = "";
            string userName = "";

            if (userData != null)
            {
                var nameString = JObject.Parse(userData);
                userName = nameString["name"]["firstName"].ToString() + " " + nameString["name"]["lastName"].ToString();
            }
            foreach (var claim in jwt.Claims)
            {
                if (claim.Type.ToLower() == "email")
                    email = claim.Value;
                if (claim.Type.ToLower() == "sub")
                    userID = claim.Value;
            }

            UserLogin = new SocialMediaLogin()
            {
                DeviceID = DependencyService.Get<IGetDeviceInfo>().GetDeviceID(),
                DeviceToken = null,
                OS = Xamarin.Essentials.DeviceInfo.Platform.ToString(),
                OSVersion = Xamarin.Essentials.DeviceInfo.Version.ToString(),
                SocialMediaID = userID,
                SocialMediaEmail = email,
                SocialMediaName = userName,
                SocialMediaSite = Shared.SocialSites.Apple,
                Lang = Preferences.Get("savedLang", null)
            };
        }

        public async static void Google_Auth(string access_token)
        {
            SocialMediaLogin UserLogin = null;
            var handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            var response = await client.GetAsync($"https://www.googleapis.com/oauth2/v3/userinfo?access_token={access_token}");
            var content = await response.Content.ReadAsStringAsync();
            var JObj = JObject.Parse(content);
            try
            {
                Preferences.Set("UserImage", JObj["picture"].ToString());
            }
            catch
            {
                Preferences.Set("UserImage", "Sticky/images/download.png");
            }

            UserLogin = new SocialMediaLogin()
            {
                DeviceID = DependencyService.Get<IGetDeviceInfo>().GetDeviceID(),
                DeviceToken = null,
                OS = Xamarin.Essentials.DeviceInfo.Platform.ToString(),
                OSVersion = Xamarin.Essentials.DeviceInfo.Version.ToString(),
                SocialMediaID = JObj["sub"].ToString(),
                SocialMediaEmail = JObj["email"].ToString(),
                SocialMediaName = JObj["name"].ToString(),
                SocialMediaSite = Shared.SocialSites.Google,
                Lang = Preferences.Get("savedLang", null)
            };

        }

        public static Task<string> GetMainData(Tuple<string, string, string> MenuMainCode_SubMenuCode_ViewName, int Page = 0, string FilterBy = "", string FilterTerm = "", string EndPoint = "getMainData", string SelectColumn = "", string ExtraColumns = "", int length = 10)
        {
            JObject JsonToken = new JObject();
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<LoginResponse>();
                var AccountID = SecureStorage.GetAsync("AccountID").Result;
                var user = conn.Table<LoginResponse>().Where(x => x.userID == AccountID).FirstOrDefault();
                JsonToken = JObject.Parse(user.userData);
            }

            if (JsonToken == null)
                return null;

            JToken MenuMains = new JObject();
            JToken MenuSubs = new JObject();
            JToken MenuSub = new JObject();
            JToken Views = new JObject();
            JToken AllPatientsView = new JObject();

            try
            {
                MenuMains = JsonToken["role"]["menuMains"];
                MenuSubs = MenuMains.Where(x => x["menuMainCode"].ToString() == MenuMainCode_SubMenuCode_ViewName.Item1).FirstOrDefault();
                MenuSub = (MenuSubs["menuSubs"] as JArray).Where(x => x["subMenuCode"].ToString() == MenuMainCode_SubMenuCode_ViewName.Item2).FirstOrDefault();
                Views = MenuSub["views"] as JArray;
                AllPatientsView = Views.Where(x => x["viewName"].ToString() == MenuMainCode_SubMenuCode_ViewName.Item3).FirstOrDefault();
            }
            catch
            { }
            var accountId = SecureStorage.GetAsync("AccountID").Result;
            var resourceID = SecureStorage.GetAsync("ResourceID").Result;
            var userID = SecureStorage.GetAsync("userID").Result;

            RequestParameters Request = new RequestParameters();
            Request.Draw = 1;
            Request.Start = Page * 10;
            Request.Length = length;

            if (AllPatientsView.HasValues)
            {
                Request.DefaultFilter = AllPatientsView["viewFilter"].ToString(); ;
                Request.SearchFilter = AllPatientsView["viewSearchFilter"].ToString();
                Request.TableTop = AllPatientsView["viewTop"].ToString();
                Request.TablePKs = AllPatientsView["viewPKs"].ToString();
                Request.SelectedColumns = AllPatientsView["viewColumns"].ToString() + ExtraColumns;
                Request.PermissionFilter = AllPatientsView["viewPermissionFilter"].ToString();
                Request.ConditionFilter = AllPatientsView["viewConditionFilter"].ToString();
                Request.ViewSort = AllPatientsView["viewSorting"].ToString();
                Request.ParentId = AllPatientsView["parentColumnName"].ToString();
                Request.EntityName = MenuSub["subMenuCode"].ToString();
                Request.EntityDisplayName = MenuSub["menuSubName"].ToString();
                Request.MenuMainName = MenuSubs["menuMainName"].ToString();
            }

            Request.Order = null;
            Request.Search = new SearchRequestItem();
            Request.FullTextSearch = null;
            Request.AccountId = accountId;

            Request.ResourceId = resourceID;
            Request.UserId = userID;
            Request.Date = new DateTimeOffset();
            Request.SelectColumn = SelectColumn;
            Request.Columns = new List<ColumnRequestItem>()
            {
                new ColumnRequestItem() {
                    Searchable = true,
                    Name = FilterBy,
                    Search = new SearchRequestItem() {
                        Value = FilterTerm
                    }
                }
            };

            var result = Shared.PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/MainDatas/{EndPoint}", JsonConvert.SerializeObject(Request));
            try
            {
                if (result != null)
                {
                    var RecordsTotal = (double)JObject.Parse(result)["result"]["recordsFiltered"];
                    //var MaxPages = Convert.ToDouble(AllPatientsView["viewMaxPageItems"].ToString());

                    if (MenuMainCode_SubMenuCode_ViewName.Item3 == "Today's Visits")
                    {
                        App.LoadMoreBookingsRequest1 = JsonConvert.SerializeObject(Request);
                        App.TotalBookingsPages1 = Math.Ceiling(RecordsTotal / Request.Length);
                    }
                    else if (MenuMainCode_SubMenuCode_ViewName.Item3 == "All Visits")
                    {
                        App.LoadMoreBookingsRequest2 = JsonConvert.SerializeObject(Request);
                        App.TotalBookingsPages2 = Math.Ceiling(RecordsTotal / Request.Length);
                    }
                    else if (MenuMainCode_SubMenuCode_ViewName.Item3 == "My Patients")
                    {
                        App.LoadMorePatientsRequest = JsonConvert.SerializeObject(Request);
                        App.TotalPages = Math.Ceiling(RecordsTotal / Request.Length);
                    }
                }
            }
            catch
            { }
            return Task.FromResult(result);
        }

        public static Task<string> GetTreeData(Tuple<string, string, string> MenuMainCode_SubMenuCode_ViewName, int Page = 1, string EndPoint = "getMainData", string SelectColumn = "")
        {
            JObject JsonToken = new JObject();
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<LoginResponse>();
                var AccountID = SecureStorage.GetAsync("AccountID").Result;
                var user = conn.Table<LoginResponse>().Where(x => x.userID == AccountID).FirstOrDefault();
                JsonToken = JObject.Parse(user.userData);
            }

            if (JsonToken == null)
                return null;

            JToken MenuMains = new JObject();
            JToken MenuSubs = new JObject();
            JToken MenuSub = new JObject();
            JToken Views = new JObject();
            JToken AllPatientsView = new JObject();

            try
            {
                MenuMains = JsonToken["role"]["menuMains"];
                MenuSubs = MenuMains.Where(x => x["menuMainCode"].ToString() == MenuMainCode_SubMenuCode_ViewName.Item1).FirstOrDefault();
                MenuSub = (MenuSubs["menuSubs"] as JArray).Where(x => x["subMenuCode"].ToString() == MenuMainCode_SubMenuCode_ViewName.Item2).FirstOrDefault();
                Views = MenuSub["views"] as JArray;
                AllPatientsView = Views.Where(x => x["viewName"].ToString() == MenuMainCode_SubMenuCode_ViewName.Item3).FirstOrDefault();
            }
            catch
            { }
            var accountId = SecureStorage.GetAsync("AccountID").Result;
            var resourceID = SecureStorage.GetAsync("ResourceID").Result;
            var userID = SecureStorage.GetAsync("userID").Result;


            if (AllPatientsView.HasValues)
            {
                treeRequest TreeData = new treeRequest()
                {
                    AccountId = accountId,
                    EntityDisplayName = MenuSub["menuSubName"].ToString(),
                    EntityName = "Locations",
                    Filter = AllPatientsView["viewFilter"].ToString(),
                    IdColumnName = AllPatientsView["viewPKs"].ToString(),
                    NameColumnName = AllPatientsView["nameColumnNme"].ToString(),
                    PageNumber = Convert.ToInt32(Page),
                    PageSize = Convert.ToInt32(AllPatientsView["viewMaxPageItems"].ToString()),
                    ParentColumnName = AllPatientsView["parentColumnName"].ToString(),
                    ParentId = "",
                    SearchText = "",
                };
                var result = Shared.PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/MainDatas/{EndPoint}", JsonConvert.SerializeObject(TreeData));

                return Task.FromResult(result);
            }
            return null;
        }
        public async static Task<string> DeleteMainData(List<string> RecordIDs, string entityDisplayName = "", string entityName = "")
        {
            APIs.Account.DeleteRequestParameter Request = new APIs.Account.DeleteRequestParameter()
            {
                EntityDisplayName = entityDisplayName,
                EntityName = entityName,
                PKs = RecordIDs
            };

            var result = Shared.PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/MainDatas/deleteMainData", JsonConvert.SerializeObject(Request));
            return result;
        }

        public static Task<string> GetDynamicLists(string Fields)
        {
            var data = Shared.PostAPI($"api/Account/{Preferences.Get("savedCulture", "en-GB")}/Account/GetDynamicListMenusItems", JsonConvert.SerializeObject(new { dynamicListMenusName = Fields }));
            return Task.FromResult(data);
        }

        public static void Google_Logout()
        {
            MessagingCenter.Send<App>(App.Current as App, "GoogleLogout");
        }

        public static void Facebook_Logout()
        {
            MessagingCenter.Send<App>(App.Current as App, "FacebookLogout");
        }

        public static string streamToBase64(Stream input)
        {
            MemoryStream ms = new MemoryStream();
            input.CopyTo(ms);
            return Convert.ToBase64String(ms.ToArray());
        }
        public static byte[] ConvertBase64ToByteArray(string base64)
        {
            try
            {
                byte[] backToBytes = Convert.FromBase64String(base64);
                return backToBytes;
            }
            catch
            { }
            return null;
        }
        public static string ConvertByteArrayToBase64(byte[] byteArray)
        {
            try
            {
                string backToBase64 = Convert.ToBase64String(byteArray);
                return backToBase64;
            }
            catch
            { }
            return "";
        }


        public static string platform { get; set; }
        public const string callbackUri = "https://api.edoctorgroup.com/socialauth/PatientsApp/PatientSocialLoginResponse/";
        public const string callbackUri_iOS = "EDSDoctors://";
        //public const string callbackUri = "https://api.edoctorgroup.com/socialauth/patientsapp/PatientSocialLoginResponse";
        public static class SocialSites
        {
            public const string Facebook = "Facebook";
            public const string Google = "Google";
            public const string Instagram = "Instagram";
            public const string Apple = "Apple";
            public const string Huawei = "Huawei";
        }
    }
}
