using System;
using SQLite;

namespace EDSDoctorsApp.ViewModels
{
    public class LoginUser
    {
        [PrimaryKey]
        public string PatientsGuid { get; set; }
        public string PatientsName { get; set; }
        public string PatientsEmail { get; set; }
        public string PatientsPassword { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
        public string NewPassword { get; set; }
        public string PatientsPhone { get; set; }
        public string Lang { get; set; }
        public string PatientsLang { get; set; }
        public string Country { get; set; }
        public string msg { get; set; }
        public string errorMessage { get; set; }
        public string SecurityCode { get; set; }
        public string OTP { get; set; }
        public string PatientsSocialMediaID { get; set; }
    }
}
