using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class Profile 
    {
        [XmlAttribute]
        public string picture { get; set; }
        [XmlAttribute]
        public string id { get; set; }
        [XmlAttribute]
        public string type { get; set; }
        [XmlAttribute]
        public string accessToken { get; set; }
        [XmlAttribute]
        public string email { get; set; }
        [XmlAttribute]
        public string name { get; set; }
        [XmlElement]
        public List<Offer> Offers { get; set; }
     
    }

   
}

