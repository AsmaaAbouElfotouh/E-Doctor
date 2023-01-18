using System;
using System.Collections.Generic;

namespace EDSDoctorsApp.ViewModels
{
    public class VMBookings
    {
        public IEnumerable<VMVisits> Bookings { get; set; }
        public dynamic obj { get; set; }
    }
}
