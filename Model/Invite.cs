using System;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class Invite
    {
        [XmlAttribute]
        public string email { get; set; }
        [XmlAttribute]
        public string invitorToken { get; set; }
        [XmlAttribute]
        public string invitorName { get; set; }
        [XmlAttribute]
        public string companySlug { get; set; }
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public string inviteToken { get; set; }
    }
}
