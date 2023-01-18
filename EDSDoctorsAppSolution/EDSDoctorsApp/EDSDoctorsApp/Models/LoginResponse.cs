using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDSDoctorsApp.Models
{
    public class LoginResponse
    {
        [PrimaryKey]
        public string userID { get; set; }
        public string userData { get; set; }
    }
}
