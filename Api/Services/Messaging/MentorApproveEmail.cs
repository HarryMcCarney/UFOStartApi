using System;
using mandrill.net.Model;

namespace UFOStart.Api.Services.Messaging
{
    public class MentorApproveEmail : IMessage
    {
        private readonly string name;
        private readonly string company;
        private readonly string roundLink;

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