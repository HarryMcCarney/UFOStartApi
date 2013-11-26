using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace UFOStart.LinkedIn
{

    [Serializable]
    [XmlRoot("people-search")]
    public class PeopleSeach
    {
        [XmlElement(ElementName = "people")]
        public People People { get; set; }
    }


    [Serializable]
    public class People
    {
        [XmlElement(ElementName = "person")]
        public List<Person> Person { get; set; }

    }

    [Serializable]
    [XmlRoot("person")]
    public class Person
    {
        [XmlIgnore]
        public string id
        {
            get { return ID.value; }
            set { }
        }

        [XmlIgnore]
        public string name
        {
            get { return Name.value; }
            set { }
        }

        [XmlIgnore]
        public string firstName
        {
            get { return FirstName.value; }
            set { }
        }

        [XmlIgnore]
        public string lastName
        {
            get { return LastName.value; }
            set { }
        }

        [XmlIgnore]
        public string relation
        {
            get { return RelationToViewer.Distance.value; }
            set { }
        }


        [XmlIgnore]
        public string headline
        {
            get { return HeadLine.value; }
            set { }
        }

        [XmlIgnore]
        public string interests
        {
            get
            {
                try
                {

                    return Interests.value;
                }
                catch (Exception exp)
                {
                    return null;
                }
            }
            set { }
        }

        [XmlIgnore]
        public string specialties
        {
            get { return Specialties.value; }
            set { }
        }

        [XmlIgnore]
        public string summary
        {
            get { return Summary.value; }
            set { }
        }

        [XmlIgnore]
        public int positions
        {
            get { return Positions.total; }
            set { }
        }


        [XmlIgnore]
        public string picture
        {
            get
            {
                if (Picture != null) return Picture.value;
                return "";
            }
            set { }
        }

        [XmlIgnore]
        public Person Intro
        {
            get
            {
                try
                {
                    return RelationToViewer.Connections.Persons[0];
                }
                catch (Exception e)
                {
                    return null;
                }
            }

        }

        [XmlIgnore]
        public List<string> skillTags
        {
            get
            {
                try
                {
                    var mySkills = new List<string>();
                    if (SkillsWrapper.SkillList != null)
                    {
                        mySkills.AddRange(SkillsWrapper.SkillList.Select(s => s.innerSkill.name.value));
                        return mySkills;
                    }
                    return null;
                }
                catch (Exception exp)
                {
                    return null;
                }
            }
        }
     
     
     
        [XmlElement(ElementName = "id")]
        public ID ID { get; set; }

        [XmlElement(ElementName = "connections")]
        public Connections Connections { get; set; }

        [XmlElement(ElementName = "name")]
        public Name Name { get; set; }

        [XmlElement(ElementName = "first-name")]
        public FirstName FirstName { get; set; }

        [XmlElement(ElementName = "last-name")]
        public LastName LastName { get; set; }

        [XmlElement(ElementName = "relation-to-viewer")]
        public RelationToViewer RelationToViewer { get; set; }

        [XmlElement(ElementName = "interests")]
        public Interests Interests { get; set; }

        [XmlElement(ElementName = "headline")]
        public HeadLine HeadLine { get; set; }

        [XmlElement(ElementName = "specialties")]
        public Specialties Specialties { get; set; }

        [XmlElement(ElementName = "summary")]
        public Summary Summary { get; set; }

        [XmlElement(ElementName = "industry")]
        public Industry Industry { get; set; }

        [XmlElement(ElementName = "picture-url")]
        public Picture Picture { get; set; }

        [XmlElement(ElementName = "positions")]
        public Positions Positions { get; set; }

        [XmlIgnore]
        public int rating { get; set; }

        [XmlElement(ElementName = "skills")]
        public SkillsWrapper SkillsWrapper { get; set; }
    }

    //THIS IS THE INNER CLASSES


    [Serializable]
    public class SkillsWrapper
    {
        [XmlAttribute]
        public string total { get; set; }

        [XmlElement(ElementName = "skill")]
        public List<Skill> SkillList { get; set; }

    }
      
    

    [Serializable]
    public class Skill
    {
        [XmlElement]
        public ID id { get; set; }
        [XmlElement]
        public Name name { get; set; }

        [XmlElement (ElementName= "skill")]
        public Skill innerSkill { get; set; }
    }


    [Serializable]
        public class ID
        {
            [XmlText]
            public string value { get; set; }
        }

    [Serializable]
    public class Positions
    {
        [XmlAttribute]
        public int total { get; set; }
    }



        [Serializable]
        public class FirstName
        {
            [XmlText]
            public string value { get; set; }
        }

        [Serializable]
        public class LastName
        {
            [XmlText]
            public string value { get; set; }
        }

        [Serializable]
        public class RelationToViewer
        {
            [XmlElement(ElementName = "distance")]
            public Distance Distance { get; set; }

            [XmlElement(ElementName = "related-connections")]
            public Connections Connections { get; set; }


        }

        [Serializable]
        public class Connections
        {
            [XmlAttribute]
            public int total { get; set; }

            [XmlElement(ElementName = "person")]
            public List<Person> Persons { get; set; }
        }

        [Serializable]
        public class Distance
        {
            [XmlText]
            public string value { get; set; }
        }


        [Serializable]
        public class HeadLine
        {
            [XmlText]
            public string value { get; set; }
        }

        [Serializable]
        public class Interests
        {
            [XmlText]
            public string value { get; set; }
        }

        [Serializable]
        public class Specialties
        {
            [XmlText]
            public string value { get; set; }
        }

        [Serializable]
        public class Summary
        {
            [XmlText]
            public string value { get; set; }
        }

        [Serializable]
        public class Industry
        {
            [XmlText]
            public string value { get; set; }
        }

        [Serializable]
        public class Picture
        {
            [XmlText]
            public string value { get; set; }
        }

        [Serializable]
        public class Name
        {
            [XmlText]
            public string value { get; set; }
        }


    }


