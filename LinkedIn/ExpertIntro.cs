using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using Model;
using UFOStart.Model;

namespace UFOStart.LinkedIn
{
    public class ExpertIntro
    {


        private  string accessToken { get; set; }
        private  string secret { get; set; }
        private  string need { get; set; }
    



        public  List<Expert> getExperts(User user, Need _need)
        {


            var experts = new List<Expert>();
            var profile = (from x in user.Profile where x.type == "LI" select x).Take(1).ToList()[0];
            accessToken = profile.accessToken;
            need = _need.name;

            var raw_contacts = getContacts();
            if (raw_contacts == null)
                return null;
            var contacts = (from x in raw_contacts.People.Person where x.firstName != "private" select x).ToList();
            if (contacts.Count == 0)
                return null;
            rankContacts(contacts);


            var bestMatches = (from x in contacts orderby x.rating descending select x).Take(4).ToList();
            foreach (var match in bestMatches)
            {
                getIntro(match);

                experts.Add(new Expert()
                    {

                        firstName = match.firstName,
                        lastName = match.lastName,
                        linkedinId = match.id,
                        picture = match.picture,
                        introFirstName = match.Intro.firstName,
                        introLastName = match.Intro.lastName,
                        introLinkedinId = match.Intro.id,
                        introPicture = getPicture(match.Intro.id),
                 });


            }

            return experts;
        }

        private  void rankContacts(List<Person> contacts )
        {
            //todo this is stubed for now but can rank based on relevance later
       
            foreach (var c in contacts)
            {

                c.rating = -1;
            }
             contacts[0].rating = 100;
        }


        private  PeopleSeach getContacts()
        {
            try
            {
                var url =
                    string.Format(
                        "https://api.linkedin.com/v1/people-search:(people:(id,relation-to-viewer,headline,first-name,last-name,specialties,summary,industry,picture-url),num-results)?keywords={0}&count=25&sort=relevance&oauth2_access_token={1}",
                        need, accessToken);
                var contacts = apiHit(url);
                if (contacts == null)
                    return null;
                var xml = new XmlDocument();
                xml.LoadXml(contacts);
                return deserialise(xml, new PeopleSeach());
            }
            catch (Exception exp)
            {
                return null;
            }

        }

        private  void getIntro(Person person)
        {
             try
            {
            if (person.id == "private") return;
            var url =
                string.Format(
                    "https://api.linkedin.com/v1/people/id={0}:(id,headline,first-name,last-name,specialties,summary,industry,picture-url,relation-to-viewer:(related-connections))?oauth2_access_token={1}", person.id, accessToken);
            var contacts = apiHit(url);
            var xml = new XmlDocument();
            xml.LoadXml(contacts);
            var intro = deserialise(xml, new Person());
            person.RelationToViewer.Connections = intro.RelationToViewer.Connections;
            }
             catch (Exception exp)
             {
             
             }
        }


        private string getPicture(string id)
        {
            try
            {
            var url =  
                string.Format(
                    "https://api.linkedin.com/v1/people/id={0}:(id,headline,first-name,last-name,specialties,summary,industry,picture-url)?oauth2_access_token={1}", id, accessToken);
            var contact = apiHit(url);
            var xml = new XmlDocument();
            xml.LoadXml(contact);
            var contactObj = deserialise(xml, new Person());
            return contactObj.picture;
              }
            catch (Exception exp)
            {
                return null;
            }
           }



        private  T deserialise<T>(XmlDocument xml, T myResult)
        {

            var mySerializer = new XmlSerializer(myResult.GetType());
            var myStream = new MemoryStream();
            xml.Save(myStream);
            myStream.Position = 0;
            var r = mySerializer.Deserialize(myStream);
            return (T) r;

        }

        private  string apiHit(string endpoint)
        {
            try
            {
                var webClient = new WebClient();
                return webClient.DownloadString(endpoint);
            }
            catch (Exception exp)
            {
                return null;
            }
        }


    }

    
}
