using System;
using System.Collections.Generic;
using System.Text;

namespace EDSDoctorsApp.Models
{
    public class ResetPasswordVM
    {
        public string email { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public string token { get; set; }
    }
}
