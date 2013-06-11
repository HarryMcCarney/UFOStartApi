using System;
using System.Xml.Serialization;
using UFOStart.Model;

namespace Model
{
    [Serializable]
    public class Application
    {
        [XmlElement]
        public User User { get; set; }
        [XmlAttribute]
        public string message { get; set; }
        [XmlAttribute]
        public string created { get; set; }
        
    }
}