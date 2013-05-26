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
        public string key { get; set; }
        [XmlAttribute]
        public bool expert { get; set; }
        [XmlElement]
        public Service Service { get; set; }

    }
}
