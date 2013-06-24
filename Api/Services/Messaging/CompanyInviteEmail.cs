using System;
using mandrill.net.Model;

namespace UFOStart.Api.Services.Messaging
{
    public class CompanyInviteEmail : IMessage
    {

        public string id { get; set; }
        public string type { get; set; }
        public string template { get; set; }
        public string recipient { get; set; }
        public string userName { get; set; }
        public string invitor { get; set; }
        public string inviteLink { get; set; }

        public CompanyInviteEmail(string _recipient, string _userName, string _invitor, string _inviteLink)
        {
            id = Guid.NewGuid().ToString();
            type = "EMAIL";
            userName = _userName;
            recipient = _recipient;
            invitor = _invitor;
            template = "CompanyInvite";
            inviteLink = _inviteLink;

        }

    }
}