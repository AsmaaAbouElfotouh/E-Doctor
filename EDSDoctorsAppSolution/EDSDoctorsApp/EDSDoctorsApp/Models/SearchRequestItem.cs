using System;
using System.Collections.Generic;
using System.Text;

namespace EDSDoctorsApp.Models
{
    public partial class SearchRequestItem
    {
        [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Value = "";

        [Newtonsoft.Json.JsonProperty("regex", Required = Newtonsoft.Json.Required.Always)]
        public bool Regex { get; set; }


    }
}
