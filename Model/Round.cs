﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using UFOStart.Model;

namespace Model
{
    [Serializable]
    public class Round  
    {
        [XmlAttribute]
        public string start { get; set; }

        [XmlAttribute]
        public string token { get; set; }
  
        [XmlElement]
        public List<Need> Needs { get; set; }

        [XmlElement]
        public List<User> Users { get; set; }
        [XmlElement]
        public List<Pledge> Pledges { get; set; }
        [XmlElement]
        public Pledge Pledge { get; set; }
        [XmlElement]
        public Template Template { get; set; }
        [XmlElement]
        public Product Product { get; set; }
        [XmlElement]
        public Workflow Workflow { get; set; }
        [XmlElement]
        public List<Invite> Invite { get; set; }
        [XmlAttribute]
        public string status { get; set; }
        [XmlElement]
        public Funding Funding { get; set; }

  

    }
}
