using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LinkedIn
{
    [Serializable]
    [XmlRoot("connections")]
    public class Connections
    {
        [XmlText]
        public string total { get; set; }

        [XmlElement(ElementName = "person")]
        public List<PersonConnect> Persons { get; set; }

    }


    [Serializable]
    [XmlRoot("person")]
    public class PersonConnect
    {
        [XmlElement(ElementName = "id")]
        public ID ID { get; set; }
    }


    [Serializable]
    public class ID
    {
        [XmlText]
        public string value { get; set; }
    }

}
