using System;
using System.Collections.Generic;
using System.Text;

namespace EDSDoctorsApp.Models
{
    public partial class OrderRequestItem
    {
        [Newtonsoft.Json.JsonProperty("column", Required = Newtonsoft.Json.Required.Always)]
        public int Column { get; set; }

        [Newtonsoft.Json.JsonProperty("dir", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Dir { get; set; }


    }
}
