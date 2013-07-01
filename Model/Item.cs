using System;
using System.Xml.Serialization;
using UFOStart.Model;

namespace Model
{
    [Serializable]
    public class Item
    {
        [XmlAttribute]
        public string type { get; set; }
        [XmlAttribute]
        public string created { get; set; }
        [XmlElement]
        public Endorsement Endorsement { get; set; }
        [XmlElement]
        public User User { get; set; }
        [XmlElement]
        public Application  Application { get; set; }
        [XmlElement]
        public Pledge Pledge { get; set; }

    }
}
