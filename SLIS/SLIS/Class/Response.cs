using System;
using System.Collections.Generic;
using System.Text;

namespace SLIS.Class
{
    class Response
    {
        public string Status { get; set; }
        public string Token { get; set; }
        public string Id { get; set; }
        public string UserType { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }

        public Response(string status, string token, string id, string usertype, string username, string name)
        {
            Status = status;
            Token = token;
            Id = id;
            UserType = usertype;
            Username = username;
            Name = name;
        }
    }
}
