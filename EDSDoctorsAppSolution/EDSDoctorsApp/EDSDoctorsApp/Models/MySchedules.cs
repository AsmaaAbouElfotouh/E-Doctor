using System;
using System.Collections.Generic;
using System.Text;

namespace EDSDoctorsApp.Models
{
    public class MySchedules
    {
        public string PK { get; set; }
        public string Location { get; set; }
        public string Days { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public DateTime Created { get; set; }
    }
}
