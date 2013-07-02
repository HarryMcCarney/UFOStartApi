using System;
using mandrill.net.Model;

namespace UFOStart.Api.Services.Messaging
{
    public class ApplicationFounderEmail : IMessage
    {
        public string name { get; set; }
        public string needName { get; set; }
        public string applicantName { get; set; }
        public string roundLink { get; set; }

        public string id { get; set; }
        public string type { get; set; }
        public string template { get; set; }
        public string recipient { get; set; }

        public ApplicationFounderEmail(string _recipient, string _name, string _needName, string _applicantName, string _roundLink)
        {
            recipient = _recipient;
            name = _name;
            needName = _needName;
            applicantName = _applicantName;
            roundLink = _roundLink;
            template = "ApplicationFounder";
            id = Guid.NewGuid().ToString();
            type = "EMAIL";
         
        }





    }
}

