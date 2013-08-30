using System;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class Slug
    {
        [XmlAttribute]
        public string type { get; set; }

        [XmlAttribute]
        public string value { get; set; }

    }
}
