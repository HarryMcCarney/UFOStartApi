using System;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class Expert
    {
        [XmlAttribute]
        public string linkedinId { get; set; }
        [XmlAttribute]
        public string firstName { get; set; }
        [XmlAttribute]
        public string lastName { get; set; }
        [XmlAttribute]
        public string picture { get; set; }
        [XmlElement]
        public Expert Intro { get; set; }

    }
}

