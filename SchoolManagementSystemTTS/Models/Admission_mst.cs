//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolManagementSystemTTS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Admission_mst
    {
        public int Adms_ID { get; set; }
        public Nullable<int> INSTID { get; set; }
        public Nullable<int> CAMPID { get; set; }
        public string FORM_NO { get; set; }
        public Nullable<System.DateTime> SUBMITTED_DT { get; set; }
        public string FIRST_NAME { get; set; }
        public string MIDDLE_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public Nullable<System.DateTime> DATE_OF_BIRTH { get; set; }
        public string RELIGION { get; set; }
        public string DOMICILE { get; set; }
        public string GENDER { get; set; }
        public string IDENTIFICATION_MARK { get; set; }
        public string USER_IMG { get; set; }
        public string ADDRESS1 { get; set; }
        public string ACAD_STATUS { get; set; }
        public Nullable<int> Cityid { get; set; }
        public Nullable<int> Stateid { get; set; }
        public Nullable<int> Countid { get; set; }
        public string FTHR_FNAME { get; set; }
        public string FTHR_MNAME { get; set; }
        public string FTHR_LNAME { get; set; }
        public string STD_CNIC { get; set; }
        public string FTHR_CNIC { get; set; }
        public string OCCUPATION { get; set; }
        public Nullable<int> SESSION_YEAR { get; set; }
        public Nullable<int> APPLIED_FOR_CLASS { get; set; }
        public string PHONE { get; set; }
        public string REMARKS { get; set; }
        public string ADDEDBY { get; set; }
        public Nullable<System.DateTime> ADDEDDATE { get; set; }
        public string UPDATEDBY { get; set; }
        public Nullable<System.DateTime> UPDATEDATE { get; set; }
    }
}
