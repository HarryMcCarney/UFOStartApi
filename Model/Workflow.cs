using System;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class Workflow
    {
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public bool enforceOrder { get; set; }
        [XmlElement]
        public Stage[] Stage { get; set; }

    }
}
