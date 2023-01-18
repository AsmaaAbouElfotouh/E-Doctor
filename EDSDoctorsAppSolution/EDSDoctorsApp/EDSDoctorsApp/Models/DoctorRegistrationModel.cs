using System;
using System.Collections.Generic;
using System.Text;

namespace EDSDoctorsApp.Models
{
    public class DoctorRegistrationModel
    {
        public string organizationName { get; set; }
        public string ownerName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
    }
}
