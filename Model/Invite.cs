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
        public string companyName { get; set; }
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public string inviteToken { get; set; }
        [XmlAttribute]
        public string userToken { get; set; }
        [XmlAttribute]
        public string role { get; set; }
        [XmlElement]
        public Need Need { get; set; }
    }
}
