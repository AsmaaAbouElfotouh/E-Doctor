using System;
using System.Collections.Generic;
using System.Text;

namespace EDSDoctorsApp.Models
{
    public partial class treeRequest    
    {

        [Newtonsoft.Json.JsonProperty("accountId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AccountId { get; set; }

        [Newtonsoft.Json.JsonProperty("parentId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ParentId = null;

        [Newtonsoft.Json.JsonProperty("entityName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EntityName { get; set; }

        [Newtonsoft.Json.JsonProperty("entityDisplayName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EntityDisplayName { get; set; }

        [Newtonsoft.Json.JsonProperty("searchText", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SearchText { get; set; }

        [Newtonsoft.Json.JsonProperty("filter", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Filter { get; set; }

        [Newtonsoft.Json.JsonProperty("idColumnName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IdColumnName { get; set; }

        [Newtonsoft.Json.JsonProperty("nameColumnName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NameColumnName { get; set; }

        [Newtonsoft.Json.JsonProperty("parentColumnName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ParentColumnName { get; set; }

        [Newtonsoft.Json.JsonProperty("pageNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PageNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("pageSize", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PageSize { get; set; }



    }
}
