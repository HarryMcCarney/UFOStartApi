using System;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class Need
    {
        [XmlAttribute]
        public string id { get; set; }
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public string status { get; set; }
        [XmlAttribute]
        public string category { get; set; }
        [XmlAttribute]
        public string description { get; set; }
        [XmlAttribute]
        public string key { get; set; }
        [XmlAttribute]
        public bool isExpert { get; set; }
        [XmlElement]
        public Service Service { get; set; }
        [XmlElement]
        public Expert Expert { get; set; }
            
    }
}
