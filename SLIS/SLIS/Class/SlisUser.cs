using System;
using System.Collections.Generic;
using System.Text;

namespace SLIS.Class
{
   public  class SlisUser
    {
        public string Username;// { get; set; }
        public string Password;// { get; set; }
        public SlisUser(string uname, string pword)
        {
            Username = uname;
            Password = pword;
        }
    }
}
