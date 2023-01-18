using System;
using System.Collections.Generic;
using System.Text;

namespace EDSDoctorsApp.Models
{
    public class ConfirmEmailModel
    {
        public string portalEmail { get; set; }
        public string portalPassword { get; set; }
        public string id { get; set; }
        public string organizationName { get; set; }
        public string ownerName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public string securityStamp { get; set; }
        public string concurrencyStamp { get; set; }
        public string portalUserId { get; set; }
    }
}
