using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Model
{
   [Serializable]
    public  class Offer
    {
       [XmlAttribute]
       public string name { get; set; }
 
    }
}
