using System;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class Skill
    {
        [XmlAttribute]
        public string name { get; set; }
    }
}
