using System;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public  class Update
    {
        [XmlAttribute]
        public string userToken { get; set; }
        [XmlAttribute]
        public string userName { get; set; }
        [XmlAttribute]
        public string userHeadline { get; set; }
        [XmlAttribute]
        public string userSlug { get; set; }
        [XmlAttribute]
        public string userPicture { get; set; }
        [XmlAttribute]
        public string text { get; set; }
        [XmlAttribute]
        public string created { get; set; }
    }
}
