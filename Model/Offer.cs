using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Model
{
   [Serializable]
    public  class Offer
    {
       [XmlAttribute]
       public string description { get; set; }
       [XmlAttribute]
       public string price { get; set; }
       [XmlAttribute]
       public string stock { get; set; }
       [XmlAttribute]
       public string created { get; set; }
       [XmlAttribute]
       public string token { get; set; }
    }
}
