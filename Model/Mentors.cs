using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using UFOStart.Model;

namespace Model
{
    [Serializable]
    public class Mentors
    {
        [XmlElement]
        public List<User> User { get; set; }
    }
}
