using EDSDoctorsApp.Helper.EMR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDSDoctorsApp.Models
{
    public partial class VisitsVM
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid Id { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsVisitsId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? VisitsVisitsId { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsAccountsId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? VisitsAccountsId { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsPatientsId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? VisitsPatientsId { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsDepartment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsDepartment { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsResourceId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? VisitsResourceId { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsLocationsId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? VisitsLocationsId { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsRoomsId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? VisitsRoomsId { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsSchedulesId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? VisitsSchedulesId { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsCcrequestId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? VisitsCcrequestId { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsSn", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long? VisitsSn { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsSnloc", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long? VisitsSnloc { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsSndep", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long? VisitsSndep { get; set; }

        [Newtonsoft.Json.JsonProperty("visitstInvoiceDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? VisitstInvoiceDate { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsInitDep", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsInitDep { get; set; }

        [Newtonsoft.Json.JsonProperty("visitstInvoiceIssuesBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitstInvoiceIssuesBy { get; set; }

        [Newtonsoft.Json.JsonProperty("visitstInvoiceIssuesById", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long? VisitstInvoiceIssuesById { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsInvoiceNotes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsInvoiceNotes { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsPatientQueueNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsPatientQueueNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsScheduleDateTime", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsScheduleDateTime { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsAttendedDateTime", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? VisitsAttendedDateTime { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsStartDateTime", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? VisitsStartDateTime { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsEndDateTime", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? VisitsEndDateTime { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsConsultationMaxDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? VisitsConsultationMaxDate { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? VisitsDate { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsDuration", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? VisitsDuration { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsPatientsInsuranceCardsId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? VisitsPatientsInsuranceCardsId { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsInsuranceDocumentation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsInsuranceDocumentation { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsPriority", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsPriority { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsType { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsCategory", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsCategory { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsCategorySub", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsCategorySub { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsStatus { get; set; }

        [Newtonsoft.Json.JsonProperty("visitspayer", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Visitspayer { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsCancelationReason", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsCancelationReason { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsReferringResourcesId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? VisitsReferringResourcesId { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsReferralsProvidersId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? VisitsReferralsProvidersId { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsMarketingChannel", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsMarketingChannel { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsDiscountsId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? VisitsDiscountsId { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsHomeIsSettled", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? VisitsHomeIsSettled { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsHomeIsSettledDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? VisitsHomeIsSettledDate { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsHomeIsSettleValue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? VisitsHomeIsSettleValue { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsHomeIsSettleBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long? VisitsHomeIsSettleBy { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsbookingPatientName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsbookingPatientName { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsbookingPatientMobile", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsbookingPatientMobile { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsPatientVisitsReason", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsPatientVisitsReason { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsPatientEvaluation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? VisitsPatientEvaluation { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsNotes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsNotes { get; set; }

        [Newtonsoft.Json.JsonProperty("created", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.String Created { get; set; }

        [Newtonsoft.Json.JsonProperty("createdById", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CreatedById { get; set; }

        [Newtonsoft.Json.JsonProperty("modified", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? Modified { get; set; }

        [Newtonsoft.Json.JsonProperty("modifiedById", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ModifiedById { get; set; }

        [Newtonsoft.Json.JsonProperty("modifiedCounts", Required = Newtonsoft.Json.Required.Always)]
        public int ModifiedCounts { get; set; }

        [Newtonsoft.Json.JsonProperty("deleted", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? Deleted { get; set; }

        [Newtonsoft.Json.JsonProperty("deletedById", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DeletedById { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsDiagnosis", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsDiagnosis { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsBriefHistory", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsBriefHistory { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsSpecimenSource", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsSpecimenSource { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsJustification", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsJustification { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsHomeAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsHomeAddress { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsIsHome", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? VisitsIsHome { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsArrivalMode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsArrivalMode { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsIsCritical", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? VisitsIsCritical { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsLabSupplierId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? VisitsLabSupplierId { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsTotalServicesPatient", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? VisitsTotalServicesPatient { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsExtraChargesPatient", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? VisitsExtraChargesPatient { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsExtraDiscountPatient", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? VisitsExtraDiscountPatient { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsExtraChargesPatientNotes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsExtraChargesPatientNotes { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsExtraDiscountPatientNotes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsExtraDiscountPatientNotes { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsTotalMedicalServicePatient", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? VisitsTotalMedicalServicePatient { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsInsuranceMaxLimitSettlement", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? VisitsInsuranceMaxLimitSettlement { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsExtraPackageCostPatient", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? VisitsExtraPackageCostPatient { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsStampsPatient", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? VisitsStampsPatient { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsTotalTaxPatient", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? VisitsTotalTaxPatient { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsOverallPatient", Required = Newtonsoft.Json.Required.Always)]
        public double VisitsOverallPatient { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsTotalServicesCompany", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? VisitsTotalServicesCompany { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsExtraChargesCompany", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? VisitsExtraChargesCompany { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsExtraDiscountCompany", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? VisitsExtraDiscountCompany { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsExtraChargesCompanyNotes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsExtraChargesCompanyNotes { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsExtraDiscountCompanyNotes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VisitsExtraDiscountCompanyNotes { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsTotalMedicalServiceCompany", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? VisitsTotalMedicalServiceCompany { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsExtraPackageCostCompany", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? VisitsExtraPackageCostCompany { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsStampsCompany", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? VisitsStampsCompany { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsTotalTaxCompany", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? VisitsTotalTaxCompany { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsOverallCompany", Required = Newtonsoft.Json.Required.Always)]
        public double VisitsOverallCompany { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsExaminationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? VisitsExaminationId { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsExamination", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Examination VisitsExamination { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsPatients", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Patient VisitsPatients { get; set; }

        [Newtonsoft.Json.JsonProperty("examinations", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Examination> Examinations { get; set; }

        [Newtonsoft.Json.JsonProperty("patientsVisitsExaminations", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PatientsVisitsExamination> PatientsVisitsExaminations { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsApprovals", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<VisitsApproval> VisitsApprovals { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsInvoices", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<VisitsInvoice> VisitsInvoices { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsPayments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<VisitsPayment> VisitsPayments { get; set; }

        [Newtonsoft.Json.JsonProperty("visitsServices", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<VisitsService> VisitsServices { get; set; }
        public List<string> VisitActions { get; set; }
        public string VisitLocation { get; set; }


    }
}
