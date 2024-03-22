using System;
using System.Collections.Generic;
using System.Text;

namespace SLIS.Class
{
    class SMSRespo
    {
        public string Status { get; set; }
        public string Response { get; set; }
        public SMSRespo(string status, string response)
        {
            Status = status;
            Response = response;
        }
    }
}
