using System;
using System.Collections.Generic;
using System.Text;

namespace EDSDoctorsApp.Models
{
    public class SocialMediaLogin
    {
        public string SocialMediaSite { get; set; }
        public string SocialMediaID { get; set; }
        public string SocialMediaName { get; set; }
        public string SocialMediaEmail { get; set; }
        public string DeviceID { get; set; }
        public string DeviceToken { get; set; }
        public string OS { get; set; }
        public string OSVersion { get; set; }
        public string Lang { get; set; }
        public string SocialMediaKey { get { return SocialMediaID.ToLower() + "@" + SocialMediaSite.ToLower(); } }
    }
}
