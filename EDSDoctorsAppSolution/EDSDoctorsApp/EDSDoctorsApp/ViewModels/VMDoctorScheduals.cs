using System;
using System.Collections.Generic;

namespace EDSDoctorsApp.ViewModels
{
    public class VMDoctorScheduals
    {
        public FindDoctors Doctors { get; set; }
        public IEnumerable<dynamic> Scheduals { get; set; }
        public dynamic obj { get; set; }
    }
}
