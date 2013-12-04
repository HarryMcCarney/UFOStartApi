using System;
using mandrill.net.Model;

namespace UFOStart.Api.Services.Messaging
{
    public class AdvisorInviteEmail  : IMessage
    {
        public string name { get; set; }
        public string needName { get; set; }
        public string company { get; set; }
        public string needLink { get; set; }
        public string invitorName { get; set; }


        public string id { get; set; }
        public string type { get; set; }
        public string template { get; set; }
        public string recipient { get; set; }

        public AdvisorInviteEmail(string _recipient, string _name, string _invitorName, string _needName, string _company, string _needLink)
        {
            recipient = _recipient;
            name = _name;
            needName = _needName;
            company = _company;
            needLink = _needLink;
            invitorName = _invitorName;
            template = "advisorinvite";
            id = Guid.NewGuid().ToString();
            type = "EMAIL";
         
        }

        





    }
}

