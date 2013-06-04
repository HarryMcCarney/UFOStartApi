using System;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class Pledge
    {

        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public string picture { get; set; }
        [XmlAttribute]
        public string network { get; set; }
        [XmlAttribute]
        public string networkId { get; set; }


    }
}
