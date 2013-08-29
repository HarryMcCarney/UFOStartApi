using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class Template
    {
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public string key { get; set; }
        [XmlAttribute]
        public string picture { get; set; }
        [XmlAttribute]
        public string logo { get; set; }
        [XmlAttribute]
        public string description { get; set; }
        [XmlAttribute]
        public bool active { get; set; }
        [XmlElement]
        public List<Need> Need { get; set; }
    }
}
