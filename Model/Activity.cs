using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class Activity
    {
        [XmlElement]
        public List<Item> Item { get; set; }

    }
}
