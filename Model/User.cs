using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
        public string token { get; set; }
        [XmlElement]
        public List<Profile> Profile { get; set; }

    }
}
