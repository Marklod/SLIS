using System;
using System.Collections.Generic;
using System.Text;

namespace SLIS.Class
{
    class SearchClass
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<RootSearch>(myJsonResponse);
        public class PatientList
        {
            public string LabNumber { get; set; }
            public string OLBNumber { get; set; }
            public string PatientName { get; set; }
            public string IDNumber { get; set; }
            public string Sex { get; set; }
            public string Address { get; set; }
            public string PhoneNumber { get; set; }
            public string DateOfBirth { get; set; }
            public string VisitDate { get; set; }
            public string PaymentMode { get; set; }
            public string Clinic { get; set; }
            public string Doctor { get; set; }
            public string ClinicalData { get; set; }
            public string Tests { get; set; }
            public string Status { get; set; }
            public string Critical { get; set; }
        }

        public class RootSearch
        {
            public string Status { get; set; }
            public List<PatientList> PatientList { get; set; }
            public string Message { get; set; }
        }
    }
}
