using System;
using System.Collections.Generic;
using System.Text;

namespace EDSDoctorsApp.Models
{
    public partial class PatientsReviewSystemsItemsOther
    {
        [Newtonsoft.Json.JsonProperty("patientsReviewSystemsItemsOtherPatientsIdOld", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long? PatientsReviewSystemsItemsOtherPatientsIdOld { get; set; }

        [Newtonsoft.Json.JsonProperty("patientsReviewSystemsItemsOtherReviewSystemsIdOld", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long? PatientsReviewSystemsItemsOtherReviewSystemsIdOld { get; set; }

        [Newtonsoft.Json.JsonProperty("patientsReviewSystemsItemsOther1", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PatientsReviewSystemsItemsOther1 { get; set; }

        [Newtonsoft.Json.JsonProperty("patientsReviewSystemsItemsOtherPatientsId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid PatientsReviewSystemsItemsOtherPatientsId { get; set; }

        [Newtonsoft.Json.JsonProperty("patientsReviewSystemsItemsOtherReviewSystemsId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid PatientsReviewSystemsItemsOtherReviewSystemsId { get; set; }


    }
}
