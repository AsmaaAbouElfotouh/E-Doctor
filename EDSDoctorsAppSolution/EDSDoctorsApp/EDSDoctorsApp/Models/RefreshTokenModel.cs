using System;
using System.Collections.Generic;
using System.Text;

namespace EDSDoctorsApp.Models
{
    public class RefreshTokenModel
    {
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
    }
}
