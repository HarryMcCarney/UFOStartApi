﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using DBVC;
using Model;
using UFOStart.Model;

namespace UFOStart.Api
{
    [Serializable]
    public class Result : IResult
    {
        [XmlAttribute]
        public string errorMessage { get; set; }
        [XmlAttribute]
        public int status { get; set; }
        [XmlAttribute]
        public string dbMessage { get; set; }
        [XmlAttribute]
        public string procName { get; set; }
        [XmlElement]
        public User User { get; set; }
        [XmlElement]
        public Template Template { get; set; }
        [XmlElement (ElementName = "Templates")]
        public List<Template> Templates { get; set; }
        [XmlElement(ElementName = "Needs")]
        public List<Need> Needs { get; set; }
        [XmlElement]
        public Need Need { get; set; }
        [XmlElement]
        public Company Company { get; set; }
        [XmlElement]
        public Activity Activity { get; set; }
        [XmlElement]
        public Round  Round { get; set; }
        [XmlElement]
        public Invite Invite { get; set; }
        [XmlElement]
        public List<Tag> Tags { get; set; }
        [XmlElement]
        public List<Company> Companies { get; set; }
        [XmlElement]
        public Mentors Mentors { get; set; }
        [XmlElement]
        public Application Application { get; set; }
        [XmlElement]
        public Service Service { get; set; }
        [XmlElement]
        public List<Service> Services { get; set; }
        [XmlElement]
        public Content Content { get; set; }
        [XmlElement]
        public Config Config { get; set; }
        [XmlElement]
        public Slug Slug { get; set; }
        [XmlElement]
        public Page Page { get; set; }
        [XmlElement]
        public List<Page> Pages { get; set; }

    }
}