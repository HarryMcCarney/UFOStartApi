using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class Template
    {
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public string key { get; set; }
        [XmlElement]
        public List<Need> Need { get; set; }
    }


}
