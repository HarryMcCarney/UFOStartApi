using System;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class Stage
    {
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public string order { get; set; }
        [XmlAttribute]
        public bool skippable { get; set; }
        [XmlAttribute]
        public bool completed { get; set; }
    }
}
