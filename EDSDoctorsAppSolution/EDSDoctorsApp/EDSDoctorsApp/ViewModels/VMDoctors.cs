using System;
using System.Collections.Generic;

namespace EDSDoctorsApp.ViewModels
{
    public class VMDoctors
    {
        public IEnumerable<FindDoctors> Doctors { get; set; }
        public dynamic Search { get; set; }
    }
}
