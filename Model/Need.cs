using System;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class Need
    {
        [XmlAttribute]
        public string name { get; set; }
    }
}
