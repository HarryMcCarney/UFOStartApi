using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class Currency
    {
        [XmlAttribute]
        public string name { get; set; }

    }
}
