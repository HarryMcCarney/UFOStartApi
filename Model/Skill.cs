using System;
using System.Xml.Serialization;

namespace UFOStart.Model
{
    [Serializable]
    public class Skill
    {
        [XmlAttribute]
        public string name { get; set; }
    }
}
