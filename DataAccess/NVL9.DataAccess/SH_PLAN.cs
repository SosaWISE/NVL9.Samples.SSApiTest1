//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NVL9.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class SH_PLAN
    {
        public int PlanId { get; set; }
        public string Name { get; set; }
        public Nullable<int> Year { get; set; }
        public string Id { get; set; }
        public Nullable<int> PreviousPremium { get; set; }
        public Nullable<int> Premium { get; set; }
        public Nullable<int> MonthlyPremium { get; set; }
        public Nullable<int> AnnualDeductible { get; set; }
        public Nullable<int> MaxOutOfPocket { get; set; }
        public Nullable<int> PrimaryCareVisits { get; set; }
        public int SpecialistVisits { get; set; }
        public Nullable<int> PreventativeServices { get; set; }
        public string InPatientHospitalization { get; set; }
        public Nullable<int> OutpatientSurgery { get; set; }
        public string HearingAidBenefit { get; set; }
        public Nullable<int> ErVisit { get; set; }
        public Nullable<int> LabTests { get; set; }
        public Nullable<int> Xray { get; set; }
        public string AnnualRXDeductible { get; set; }
        public Nullable<int> Tier1 { get; set; }
        public Nullable<int> Tier2 { get; set; }
        public string Tier3 { get; set; }
        public string Tier4 { get; set; }
        public string Tier5 { get; set; }
        public string AnnualRxDeductibleMail { get; set; }
        public Nullable<int> Tier1Mail { get; set; }
        public Nullable<int> Tier2Mail { get; set; }
        public string Tier3Mail { get; set; }
        public string Tier4Mail { get; set; }
        public string Tier5Mail { get; set; }
        public string SummaryBenefitsURL { get; set; }
        public string SummaryBenefitsSpanishURL { get; set; }
        public string PremiumSummaryURL { get; set; }
        public string EvidenceCoverageSpanishURL { get; set; }
        public string EvidenceCoverageURL { get; set; }
    }
}
