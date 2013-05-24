using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mandrill.net.Model;

namespace UFOStart.Api.Services.Messaging
{
    public class WelcomeEmail : IMessage
    {

        public string id { get; set; }
        public string type { get; set; }
        public string template { get; set; }
        public string recipient { get; set; }
        public string userName { get; set; }

        public WelcomeEmail(string _recipient, string _userName)
        {
            id = Guid.NewGuid().ToString();
            type = "EMAIL";
            userName = _userName;
            recipient = _recipient;
            template = "WelcomeEmail";
        }

    }
}