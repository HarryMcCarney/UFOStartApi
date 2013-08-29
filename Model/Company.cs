using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Model;

namespace UFOStart.Model
{
    [Serializable]
    public class Company
    {
        [XmlAttribute]
        public string token { get; set; }
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public string slug { get; set; }
        [XmlAttribute]
        public string description { get; set; }
        [XmlAttribute]
        public string angelListId { get; set; }
        [XmlAttribute]
        public string angelListToken { get; set; }
        [XmlElement]
        public Template Template { get; set; }
        [XmlElement]
        public List<Template> Templates { get; set; }
        [XmlElement]
        public List<Round> Rounds { get; set; }
        [XmlElement]
        public Round Round { get; set; }
        [XmlElement]
        public List<User> Users { get; set; }
        [XmlAttribute]
        public string url { get; set; }
        [XmlAttribute]
        public string logo { get; set; }
        [XmlAttribute]
        public string tagString { get; set; }
        [XmlAttribute]
        public string pitch { get; set; }
        [XmlAttribute]
        public string slideShare { get; set; }
        [XmlAttribute]
        public string video { get; set; }
        [XmlElement]
        public List<Picture> Pictures { get; set; }
        [XmlElement]
        public List<Update> Updates { get; set; }
        [XmlElement]
        public Update Update { get; set; }
        [XmlElement]
        public User User { get; set; }
        [XmlAttribute]
        public string roundTemplateName { get; set; }
        [XmlElement]
        public List<User> Mentors { get; set; }
        [XmlAttribute]
        public string currency { get; set; }
    }

    
}