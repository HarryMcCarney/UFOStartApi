using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class Search
    {
        [XmlElement]
        public List<Tag> Tags { get; set; }
    }
}
