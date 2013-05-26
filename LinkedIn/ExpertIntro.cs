using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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
    



        public  Expert getExpert(User user, Need _need)
        {
            var profile = (from x in user.Profile where x.type == "LI" select x).Take(1).ToList()[0];
            accessToken = profile.accessToken;
            secret = profile.secret;
            need = _need.name;

            var contacts = (from x in getContacts().People.Person where x.firstName != "private" select x).ToList();
            if (contacts.Count == 0)
                return null;
            rankContacts(contacts);
            var bestMatch = (from x in contacts orderby x.rating descending select x).Take(1).ToList()[0];
            getIntro(bestMatch);

            var expert = new Expert()
                {
                    firstName = bestMatch.firstName,
                    lastName = bestMatch.lastName,
                    linkedinId = bestMatch.id,
                    picture = bestMatch.picture,
                    introFirstName = bestMatch.Intro.firstName,
                    introLastName = bestMatch.Intro.lastName,
                    introLinkedinId = bestMatch.Intro.id,
                    introPicture = bestMatch.Intro.picture,
                };

            return expert;
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
            var url = string.Format("http://api.linkedin.com/v1/people-search:(people:(id,relation-to-viewer,headline,first-name,last-name,specialties,summary,industry,picture-url),num-results)?keywords={0}&count=25&sort=relevance",need);
           var contacts = apiHit(url);
           var xml = new XmlDocument();
           xml.LoadXml(contacts);
           return deserialise(xml, new PeopleSeach());
        }

        private  void getIntro(Person person)
        {
            if (person.id == "private") return;
            var url =
                string.Format(
                    "http://api.linkedin.com/v1/people/id={0}:(id,headline,first-name,last-name,specialties,summary,industry,picture-url,relation-to-viewer:(related-connections))", person.id);
            var contacts = apiHit(url);
            var xml = new XmlDocument();
            xml.LoadXml(contacts);
            var intro = deserialise(xml, new Person());
            person.RelationToViewer.Connections = intro.RelationToViewer.Connections;
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

            string yelpSearchURL = endpoint;
            string yelpConsumerKey = "8qim4hatqh0z";
            string yelpConsumerSecret = "hSYEq3VJO9Ol82hw";
            string yelpRequestToken = accessToken;
            string yelpRequestTokenSecret = secret;

            Twitterizer.OAuthTokens ot = new Twitterizer.OAuthTokens();
            ot.AccessToken = yelpRequestToken;
            ot.AccessTokenSecret = yelpRequestTokenSecret;
            ot.ConsumerKey = yelpConsumerKey;
            ot.ConsumerSecret = yelpConsumerSecret;

            string formattedUri = String.Format(CultureInfo.InvariantCulture,
                                                yelpSearchURL, "");
            Uri url = new Uri(formattedUri);
            Twitterizer.WebRequestBuilder wb = new Twitterizer.WebRequestBuilder(url, Twitterizer.HTTPVerb.GET, ot);
            System.Net.HttpWebResponse wr = wb.ExecuteRequest();
            StreamReader sr = new StreamReader(wr.GetResponseStream());
            return sr.ReadToEnd();


        }


    }

    
}
