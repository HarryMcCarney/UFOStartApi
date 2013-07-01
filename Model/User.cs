using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Model;
namespace UFOStart.Model
{

    [Serializable]
    public class User
    {
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public string email { get; set; }
        [XmlAttribute]
        public string pwd { get; set; }
        [XmlAttribute]
        public string picture { get; set; }
        [XmlAttribute]
        public string token { get; set; }
        [XmlAttribute]
        public bool unconfirmed { get; set; }
        [XmlElement]
        public List<Profile> Profile { get; set; }
        [XmlElement]
        public Company Company { get; set; }

        [XmlElement]
        public List<Company> Companies { get; set; }
        [XmlElement]
        public List<Application> Applications { get; set; }
        [XmlElement]
        public List<Skill> Skills { get; set; }
        [XmlAttribute]
        public string headline { get; set; }
        [XmlAttribute]
        public string role { get; set; }
        [XmlAttribute]
        public string endorserToken { get; set; }
        [XmlAttribute]
        public int startupValue { get; set; }

        [XmlElement]
        public List<Endorsement> Endorsements { get; set; }


    }
}


