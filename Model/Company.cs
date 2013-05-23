using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Model;

namespace UFOStart.Model
{
    [Serializable]
    public class Company
    {
        [XmlAttribute]
        public string token { get; set; }
        [XmlAttribute]
        public string name { get; set; }
        [XmlElement]
        public Template Template { get; set; }


        [XmlElement (ElementName = "Templates")]
        public List<Template> Templates { get; set; }
        [XmlElement(ElementName = "Rounds")]
        public List<Round> Rounds { get; set; }
    }

    
}