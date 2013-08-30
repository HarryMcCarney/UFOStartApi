using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class Config
    {
        [XmlElement]
        public List<Category> Categories { get; set; }
        [XmlElement]
        public List<Role> Roles { get; set; }
        [XmlElement]
        public List<Currency> Currency { get; set; }
    }
}
