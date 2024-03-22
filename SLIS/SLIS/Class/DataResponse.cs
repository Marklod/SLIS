using System;
using System.Collections.Generic;
using System.Text;

namespace SLIS.Class
{
    class DataResponse
    {
        public string status { get; set; }
        public string response { get; set; } 

        public DataResponse(string stat, string resp)
        {
            status = stat;
            response = resp; 
        }
    }
}
