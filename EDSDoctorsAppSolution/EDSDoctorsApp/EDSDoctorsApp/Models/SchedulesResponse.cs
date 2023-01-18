using System;
using System.Collections.Generic;
using System.Text;

namespace EDSDoctorsApp.Models
{
    public class SchedulesResponse
    {
        public string PK { get; set; }
        public string DoctorName { get; set; }
        public string LocationName { get; set; }
        public string SchedulesMode { get; set; }
        public string SchedulesStartDate { get; set; }
        public DateTime Created { get; set; }
        public object Modified { get; set; }
        public string SchedulesResourcesID { get; set; }
    }

}
