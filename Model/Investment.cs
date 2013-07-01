using System;
using System.Xml.Serialization;
using UFOStart.Model;

namespace Model
{
    [Serializable]
    public  class Investment
    {
        [XmlElement]
        public User User { get; set; }
        [XmlAttribute]
        public string created { get; set; }
        [XmlAttribute]
        public string amount { get; set; }
    }
}
