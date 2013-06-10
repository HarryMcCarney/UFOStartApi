using System;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class Tag
    {
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public string description { get; set; }

    }
}
