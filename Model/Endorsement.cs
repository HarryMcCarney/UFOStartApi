using System;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class Endorsement
    {
        [XmlAttribute]
        public string endorserToken { get; set; }
        [XmlAttribute]
        public string endorserSlug { get; set; }
        [XmlAttribute]
        public string endorserName { get; set; }
        [XmlAttribute]
        public string endorserPicture { get; set; }
        [XmlAttribute]
        public string endorseeName { get; set; }
        [XmlAttribute]
        public string endorseeHeadline { get; set; }
        [XmlAttribute]
        public string endorseePicture { get; set; }
        [XmlAttribute]
        public string endorseeSkills { get; set; }
        [XmlAttribute]
        public string endorseeLinkedinId { get; set; }
        [XmlAttribute]
        public string needSlug { get; set; }
        [XmlAttribute]
        public string needName { get; set; }
        [XmlAttribute]
        public string endorserHeadline { get; set; }
        [XmlAttribute]
        public string created { get; set; }
        [XmlAttribute]
        public string companySlug { get; set; }
        [XmlAttribute]
        public string companyName { get; set; }

    }
}
