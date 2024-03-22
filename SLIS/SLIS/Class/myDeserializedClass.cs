using System;
using System.Collections.Generic;
using System.Text;

namespace SLIS.Class
{
    class myDeserializedClass
    {
        public class Credential
        {
            public string ReportedBy { get; set; }
            public string AuthorizedBy { get; set; }
            public string ReportDate { get; set; }
        }

        public class PatientDetailes
        {
            public string LabNumber { get; set; }
            public string OLBNumber { get; set; }
            public string PatientName { get; set; }
            public string IDNumber { get; set; }
            public object Sex { get; set; }
            public object Address { get; set; }
            public string PhoneNumber { get; set; }
            public string DateOfBirth { get; set; }
            public string VisitDate { get; set; }
            public string PaymentMode { get; set; }
            public object Clinic { get; set; }
            public object Doctor { get; set; }
            public string ClinicalData { get; set; }
            public string Tests { get; set; }
            public string Status { get; set; }
            public string Critical { get; set; }
        }

        public class Profiles
        {
            public string Profile { get; set; }
            public List<Result> Results { get; set; }
            public string AutoComment { get; set; }
            public string AdditionalComment { get; set; }
            public bool IsVisible { get; set; }
            public int TheHeight { get; set; }
            public string ReleaseStatus { get; set; }
            public bool IsVisibleRelease { get; set; }
            public string image { get; set; }
        }

        public class Result
        {
            public string Test { get; set; }
            public string result { get; set; }
            public string Units { get; set; }
            public string Flag { get; set; }
            public string Range { get; set; }
            public string Comment { get; set; }
        }

        public class Root
        {
            public string Status { get; set; }
            public string Message { get; set; }
            public string LabNumber { get; set; }
            public PatientDetailes PatientDetailes { get; set; }
            public List<Profiles> Profile { get; set; }  
            public Credential Credential { get; set; }
            public string PDF { get; set; }
             
        }

        public class ReleaseRoot
        {
            public string Status { get; set; }
            public List<TestResStatus> TestResStatus { get; set; }
            public string Message { get; set; }
        }

        public class TestResStatus
        {
            public string Test { get; set; }
            public string Capture_Status { get; set; }
            public string Authorize_Status { get; set; }
            public string Release_Status { get; set; }
            public string AmmendStatus { get; set; }
            public string DeleteStatus { get; set; }
        }



    }
}
