using System;
using mandrill.net.Model;

namespace UFOStart.Api.Services.Messaging
{
    public class ApplicationFounderEmail : IMessage
    {
        private readonly string name;
        private readonly string _needName;
        private readonly string _applicantName;
        private readonly string company;
        private readonly string roundLink;

        public string id { get; set; }
        public string type { get; set; }
        public string template { get; set; }
        public string recipient { get; set; }

        public ApplicationFounderEmail(string recipient, string name, string needName, string applicantName, string roundLink)
        {
            this.recipient = recipient;
            this.name = name;
            _needName = needName;
            _applicantName = applicantName;
            this.roundLink = roundLink;
            template = "ApplicationFounder";
            id = Guid.NewGuid().ToString();
            type = "EMAIL";
         
        }





    }
}

