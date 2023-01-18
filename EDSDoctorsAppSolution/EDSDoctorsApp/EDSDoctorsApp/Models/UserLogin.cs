using System;
namespace EDSDoctorsApp.Models
{
    public class UserLogin
    {
        public string credEncrypted = string.Empty;
        public string email = string.Empty;
        public string password = string.Empty;
        public bool rememberMe = true;
    }
}
