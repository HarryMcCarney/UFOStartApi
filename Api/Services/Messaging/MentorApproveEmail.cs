using System;
using mandrill.net.Model;

namespace UFOStart.Api.Services.Messaging
{
    public class MentorApproveEmail : IMessage
    {
        public string name { get; set; }
        public string company { get; set; }
        public string roundLink { get; set; }

        public string id { get; set; }
        public string type { get; set; }
        public string template { get; set; }
        public string recipient { get; set; }

        public MentorApproveEmail(string recipient, string name, string company, string roundLink)
        {
            this.recipient = recipient;
            this.name = name;
            this.company = company;
            this.roundLink = roundLink;
            template = "MentorApprove";
            id = Guid.NewGuid().ToString();
            type = "EMAIL";
        }





    }
}