using System;
using SQLite;

namespace EDSDoctorsApp.ViewModels
{
    public class Bookings
    {
        [PrimaryKey]
        public string PatientsVisitsGUID { get; set; }
        public string Status { get; set; }
        public string AddStatus { get; set; }
        public string SchedulesID { get; set; }
        public DateTime SchedulesEndTime { get; set; }
        public string ResourcesGender { get; set; }
        public string UsersImageMIME { get; set; }
        public string UsersImage { get; set; }
        public string PatientsVisitsLocationsID { get; set; }
        public string PatientsVisitsResourceID { get; set; }
        public string CareerLevelsName { get; set; }
        public string CareerLevelsNameAR { get; set; }
        public string Name { get; set; }
        public string LocationsWebProfileAddress { get; set; }
        public string Building { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string SpecialityName { get; set; }
        public string Scheduled { get; set; }
        public string Priority { get; set; }
        public string Actions { get; set; }
        public DateTime PatientsVisitsGetVisitDate { get; set; }
        public string Investigations { get; set; }
        public string Diagnosis { get; set; }
        public string Treatments { get; set; }
        public string Rating { get; set; }
    }
}
