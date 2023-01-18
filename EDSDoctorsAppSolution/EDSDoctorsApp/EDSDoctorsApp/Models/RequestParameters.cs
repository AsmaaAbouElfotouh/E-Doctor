using System;
using System.Collections.Generic;
using System.Text;

namespace EDSDoctorsApp.Models
{
    public partial class RequestParameters
    {
        [Newtonsoft.Json.JsonProperty("draw", Required = Newtonsoft.Json.Required.Always)]
        public int Draw { get; set; }

        [Newtonsoft.Json.JsonProperty("start", Required = Newtonsoft.Json.Required.Always)]
        public int Start { get; set; }

        [Newtonsoft.Json.JsonProperty("length", Required = Newtonsoft.Json.Required.Always)]
        public int Length { get; set; }

        [Newtonsoft.Json.JsonProperty("defaultFilter", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DefaultFilter { get; set; }

        [Newtonsoft.Json.JsonProperty("searchFilter", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SearchFilter { get; set; }

        [Newtonsoft.Json.JsonProperty("tableTop", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TableTop { get; set; }

        [Newtonsoft.Json.JsonProperty("tablePKs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TablePKs { get; set; }

        [Newtonsoft.Json.JsonProperty("selectedColumns", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SelectedColumns { get; set; }

        [Newtonsoft.Json.JsonProperty("permissionFilter", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PermissionFilter { get; set; }

        [Newtonsoft.Json.JsonProperty("conditionFilter", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ConditionFilter { get; set; }

        [Newtonsoft.Json.JsonProperty("viewSort", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ViewSort { get; set; }

        [Newtonsoft.Json.JsonProperty("columns", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<ColumnRequestItem> Columns { get; set; }

        [Newtonsoft.Json.JsonProperty("order", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<OrderRequestItem> Order { get; set; }

        [Newtonsoft.Json.JsonProperty("search", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SearchRequestItem Search { get; set; }

        [Newtonsoft.Json.JsonProperty("fullTextSearch", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public FullTextSearch FullTextSearch { get; set; }

        [Newtonsoft.Json.JsonProperty("entityName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EntityName { get; set; }

        [Newtonsoft.Json.JsonProperty("entityDisplayName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EntityDisplayName { get; set; }

        [Newtonsoft.Json.JsonProperty("accountId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AccountId { get; set; }

        [Newtonsoft.Json.JsonProperty("menuMainName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MenuMainName { get; set; }

        [Newtonsoft.Json.JsonProperty("resourceId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ResourceId { get; set; }

        [Newtonsoft.Json.JsonProperty("parentId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ParentId = null;

        [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UserId = null;

        [Newtonsoft.Json.JsonProperty("date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? Date = null;

        [Newtonsoft.Json.JsonProperty("selectColumn", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SelectColumn = null;


    }
}
