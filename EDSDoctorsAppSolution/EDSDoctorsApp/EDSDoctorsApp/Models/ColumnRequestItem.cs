using System;
using System.Collections.Generic;
using System.Text;

namespace EDSDoctorsApp.Models
{
    public partial class ColumnRequestItem
    {
        [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Data { get; set; }

        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("searchable", Required = Newtonsoft.Json.Required.Always)]
        public bool Searchable { get; set; }

        [Newtonsoft.Json.JsonProperty("orderable", Required = Newtonsoft.Json.Required.Always)]
        public bool Orderable { get; set; }

        [Newtonsoft.Json.JsonProperty("search", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SearchRequestItem Search { get; set; }

        [Newtonsoft.Json.JsonProperty("fullTextSearch", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public FullTextSearch FullTextSearch { get; set; }


    }
}
