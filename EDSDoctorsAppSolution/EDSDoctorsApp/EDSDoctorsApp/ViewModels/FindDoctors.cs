using SQLite;
using System;
namespace EDSDoctorsApp.ViewModels
{
    public class FindDoctors
    {

        public string ResourcesID { get; set; }
        public string LocationsPhone1 { get; set; }
        public string LocationsPhone2 { get; set; }
        public bool Activated { get; set; }
        public bool HasEmail { get; set; }
        public DateTime NextAvailable { get; set; }
        public string ResourcesGender { get; set; }
        public string ResourcesGUID { get; set; }
        public string LocationsGUID { get; set; }
        public string ResourcesName { get; set; }
        public string SpecialtiesName { get; set; }
        public string Building { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string CareerLevelsName { get; set; }
        public string CareerLevelsNameAR { get; set; }
        public string UsersImage { get; set; }
        public string UsersImageMIME { get; set; }
        public Boolean IsFav { get; set; }

        //[Ignore]
        public string imgSrc { get; set; }
        //[Ignore]
        public string CounntryCity { get; set; }
        //[Ignore]
        public string AccountsActivated { get; set; }
        //[Ignore]
        public string AccountsOwnerEmail { get; set; }
        //[Ignore]
        public DateTime End { get; set; }
        //[Ignore]
        public string SchedulesResourcesID { get; set; }
        public string SID { get; set; }
        //[Ignore]
        public string LocationsID { get; set; }
        //[Ignore]
        public string SchedulesLocationsID { get; set; }
        //[Ignore]
        public string ResourcesSpecialtiesID { get; set; }
        //[Ignore]
        public string ResourcesDirectoryBriefing { get; set; }
        //[Ignore]
        public string LocationsWebProfileAddress { get; set; }
        //[Ignore]
        public string SchedulesID { get; set; }
        //[Ignore]
        public string ResourcesAccountsID { get; set; }
        //[Ignore]
        public string VGUID { get; set; }
        //[Ignore]
        public string LocationsName { get; set; }
        //[Ignore]
        public string AddStatus { get; set; }
        [Ignore]
        public dynamic SearchData { get; set; }
        //[Ignore]
        public string Lang { get; set; }
        //[Ignore]
        public string SerializedDoctor { get; set; }
    }
}
