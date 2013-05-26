using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using UFOStart.Model;

namespace Model
{
    [Serializable]
    public class Round
    {
        [XmlAttribute]
        public string start { get; set; }

        [XmlAttribute]
        public string token { get; set; }
  
        [XmlElement (ElementName = "Needs")]
        public List<Need> Needs { get; set; }

        [XmlElement(ElementName = "Users")]
        public List<User> Users { get; set; }

    }
}
