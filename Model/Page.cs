using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class Page
    {
        [XmlAttribute]
        public string url { get; set; }
        [XmlAttribute]
        public string title {get;set;}
        [XmlAttribute]
        public string metaKeywords { get; set; }
    }
}
