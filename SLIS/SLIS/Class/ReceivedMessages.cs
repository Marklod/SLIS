using System;
using System.Collections.Generic;
using System.Text;

namespace SLIS.Class
{
    class ReceivedMessages
    {
        public string MsgID { get; set; }
        public string MsgType { get; set; }
        public string MsgFrom { get; set; }
        public string MsgTo { get; set; }
        public string Test { get; set; }
        public string PostDate { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public string OpenedBy { get; set; }
        public string OpenedDate { get; set; }

        public ReceivedMessages(string id, string type, string ffrom, string mto, string tst, string pdate, string msg, string stat, string oby, string odat)
        {
            MsgID = id;
            MsgType = type;
            MsgFrom = ffrom;
            MsgTo = mto;
            Test = tst;
            PostDate = pdate;
            Message = msg;
            Status = stat;
            OpenedBy = oby;
            OpenedDate = odat;
        }

        public ReceivedMessages()
        {
        }
    }
}
