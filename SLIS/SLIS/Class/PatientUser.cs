using System;
using System.Collections.Generic;
using System.Text;

namespace SLIS.Class
{
    class PatientUser
    {
        public string IDNumber { get; set; }
        public string PatientName { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

        public PatientUser(string idnumber, string patientname, string dob, string phonenumber, string password, string email, string gender)
        {
            IDNumber = idnumber;
            PatientName = patientname;
            DateOfBirth = dob;
            PhoneNumber = phonenumber;
            Password = password;
            Email = email;
            Gender = gender;
        }
    }
}
