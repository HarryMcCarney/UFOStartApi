using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class Funding
    {

        [XmlAttribute]
        public string amount { get; set; }
        [XmlAttribute]
        public string valuation { get; set; }
        [XmlAttribute]
        public string description { get; set; }
        [XmlElement]
        public List<Investment> Investments { get; set; }
        [XmlElement]
        public Investment Investment { get; set; }
    }
}
