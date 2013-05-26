using System;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class Service
    {
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public string url { get; set; }
    }
}