using System;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public   class Picture
    {
        [XmlAttribute]
        public string url { get; set; }
    }
}
