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
        [XmlAttribute]
        public string comapnyLogo { get; set; }
        [XmlAttribute]
        public string companyName { get; set; }
        [XmlAttribute]
        public string companyToken { get; set; }
        [XmlAttribute]
        public string companySlug { get; set; }
        [XmlAttribute]
        public string need { get; set; }

        
    }
}