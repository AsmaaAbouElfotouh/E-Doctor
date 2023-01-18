using System;
namespace EDSDoctorsApp.ViewModels
{
    public class RegistrationVM
    {
        public string PatientsGuid { get; set; }
        public string PatientsEmail { get; set; }
        public string SecurityCode { get; set; }
        public string errorMessage { get; set; }
    }
}
