using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class Invites
    {
        [XmlElement]
        public List<Invite> Invite { get; set; }
    }
}
