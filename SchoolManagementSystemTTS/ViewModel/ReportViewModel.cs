using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementSystemWebApplication.ViewModel
{

    public class admissionReportModel
    {
        public int Adms_ID { get; set; }
        public string Institute { get; set; }
        public string Campus { get; set; }
        public string USERID { get; set; }
        public string FORM_NO { get; set; }
        public System.DateTime SUBMITTED_DT { get; set; }
        public string FIRST_NAME { get; set; }
        public string MIDDLE_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public System.DateTime DATE_OF_BIRTH { get; set; }
        public string RELIGION { get; set; }
        public string DOMICILE { get; set; }
        public string GENDER { get; set; }
        public string IDENTIFICATION_MARK { get; set; }
        public string USER_IMG { get; set; }
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        public string ADDRESS3 { get; set; }
        public string ACAD_STATUS { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string FTHR_FNAME { get; set; }
        public string FTHR_MNAME { get; set; }
        public string FTHR_LNAME { get; set; }
        public string STD_CNIC { get; set; }
        public string FTHR_CNIC { get; set; }
        public string OCCUPATION { get; set; }
        public string SESSION_YEAR { get; set; }
        public string Classdescription { get; set; }
        public decimal DECIDEDAMT { get; set; }
        public decimal TutionFee { get; set; }
        public decimal FeesPaid { get; set; }
        public string PHONE { get; set; }
        public string REMARKS { get; set; }

    }





}