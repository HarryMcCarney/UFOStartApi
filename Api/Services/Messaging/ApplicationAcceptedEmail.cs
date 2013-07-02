using System;
using mandrill.net.Model;

namespace UFOStart.Api.Services.Messaging
{
    public class ApplicationAcceptedEmail  : IMessage
    {
        public string name { get; set; }
        public string needName { get; set; }
        public string company { get; set; }
        public string roundLink { get; set; }


        public string id { get; set; }
        public string type { get; set; }
        public string template { get; set; }
        public string recipient { get; set; }

        public ApplicationAcceptedEmail(string _recipient, string _name, string _needName, string _company, string _roundLink)
        {
            recipient = _recipient;
            name = _name;
            needName = _needName;
            company = _company;
            roundLink = _roundLink;
            template = "ApplicationAccepted";
            id = Guid.NewGuid().ToString();
            type = "EMAIL";
         
        }





    }
}

