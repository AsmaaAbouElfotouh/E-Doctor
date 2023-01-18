using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using EDSDoctorsApp.Resources;
using EDSDoctorsApp.Helper.EMR;

namespace EDSDoctorsApp.Models
{
    public class CompleteProfile
    {
        public DoctorProfile DoctorProfile { get; set; }
        public List<Locations> Locations { get; set; } = new List<Locations>();
    }
    public class DoctorProfile
    {
        public Guid DoctorID { get; set; }
        [Required]
        [Display(Name = nameof(AppResources.Name), ResourceType = typeof(AppResources))]
        public string DoctorName { get; set; }
        [Required]
        //[Display(Name = nameof(AppResources.OrganizationName), ResourceType = typeof(AppResources))]
        public string OrganizationName { get; set; }

        [Required]
        [Display(Name = nameof(AppResources.Gender), ResourceType = typeof(AppResources))]
        public string DoctorGender { get; set; }
        [Required]
        [Display(Name = nameof(AppResources.Degree), ResourceType = typeof(AppResources))]
        public string DoctorDegree { get; set; }
        [Required]
        [Display(Name = nameof(AppResources.Speciality), ResourceType = typeof(AppResources))]
        public Guid DoctorSpeciality { get; set; }

        //[Display(Name = nameof(AppResources.Image), ResourceType = typeof(AppResources))]
        public byte[] DoctorImage { get; set; }
    }
    public class LocationSchedule
    {
        //[Display(Name = nameof(AppResources.Days), ResourceType = typeof(AppResources))]
        public string Days { get; set; }
        //[Display(Name = nameof(AppResources.StartTime), ResourceType = typeof(AppResources))]

        public TimeSpan StartTime { get; set; }
        //[Display(Name = nameof(AppResources.EndTime), ResourceType = typeof(AppResources))]

        public TimeSpan EndTime { get; set; }
    }

    public class Locations
    {
        //[Display(Name = nameof(AppResources.LocationID), ResourceType = typeof(AppResources))]
        public string LocationsName { get; set; }
        public string LocationsCountry { get; set; }
        public string LocationsCity { get; set; }
        public string LocationsDistrict { get; set; }
        public string LocationsBuilding { get; set; }
        public string LocationsStreet { get; set; }
        public string LocationsPostalCode { get; set; }
        public string LocationsLandmark { get; set; }
        public List<LocationSchedule> Schedule { get; set; } = new List<LocationSchedule>();

    }

    public class CompleteProfileViews
    {
        public List<DropDownListModel> Gender { get; set; }
        public List<DropDownListModel> Degree { get; set; }
        public List<DropDownListModel> Specialties { get; set; }
        public List<DropDownListModel> Countries { get; set; }
        public List<DropDownListModel> Cities { get; set; }
        public List<DropDownListModel> Districts { get; set; }
        public CompleteProfile Profile { get; set; }


    }
}
