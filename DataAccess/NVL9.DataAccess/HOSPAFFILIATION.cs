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
    
    public partial class HOSPAFFILIATION
    {
        public int HOSPAFFILIATION_ID { get; set; }
        public Nullable<int> PRVDR_ID { get; set; }
        public string HOSPITAL_NM { get; set; }
        public string URL { get; set; }
        public string FACILITY_ID { get; set; }
        public string PRIMARY_FLG { get; set; }
        public string FCILITY_STATUS { get; set; }
    
        public virtual PROVIDER PROVIDER { get; set; }
    }
}
