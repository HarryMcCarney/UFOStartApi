using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class Product
    {
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public string picture { get; set; }
        [XmlAttribute]
        public string token { get; set; }
        [XmlAttribute]
        public string description { get; set; }
        [XmlAttribute]
        public string video { get; set; }
        [XmlElement]
        public List<Offer> Offers { get; set; }
    }
}

