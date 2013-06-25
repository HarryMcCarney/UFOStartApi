using System;
using mandrill.net.Model;

namespace UFOStart.Api.Services.Messaging
{
    public class ApplicationFounderEmail : IMessage
    {
        private readonly string name;
        private readonly string needName;
        private readonly string applicantName;
        private readonly string company;
        private readonly string roundLink;

        public string id { get; set; }
        public string type { get; set; }
        public string template { get; set; }
        public string recipient { get; set; }

        public ApplicationFounderEmail(string recipient, string name, string _needName, string _applicantName, string roundLink)
        {
            this.recipient = recipient;
            this.name = name;
            needName = _needName;
            applicantName = _applicantName;
            this.roundLink = roundLink;
            template = "ApplicationFounder";
            id = Guid.NewGuid().ToString();
            type = "EMAIL";
         
        }





    }
}

