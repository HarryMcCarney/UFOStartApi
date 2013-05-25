﻿using System;
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


        private static string accessToken { get; set; }
        private static string secret { get; set; }
        private static string need { get; set; }
    



        public static Expert getExpert(User user, Need _need)
        {
            var profile = (from x in user.Profile where x.type == "LI" select x).Take(1).ToList()[0];
            accessToken = profile.accessToken;
            secret = profile.secret;
            need = _need.name;

            var contacts = getContacts();
            rankContacts(contacts.People.Person);
            var bestMatch = (from x in contacts.People.Person orderby x.rating descending select x).Take(1).ToList()[0];
            getIntro(bestMatch);


            var intro = new Expert()
            {
                firstName = bestMatch.Intro.firstName,
                lastName = bestMatch.Intro.lastName,
                linkedinId = bestMatch.Intro.id,
                picture = bestMatch.Intro.picture,
                   
            };
            var expert = new Expert()
                {
                    firstName = bestMatch.firstName,
                    lastName = bestMatch.lastName,
                    linkedinId = bestMatch.id,
                    picture = bestMatch.picture,
                    Intro = intro
                };

            return expert;
        }

        private static void rankContacts(List<Person> contacts )
        {
            //todo this is stubed for now but can rank based on relevance later
            foreach (var c in contacts)
            {
                c.rating = -1;
            }
            contacts[0].rating = 100;
        }


        private static PeopleSeach getContacts()
        {
            var url = "http://api.linkedin.com/v1/people-search:(people:(id,relation-to-viewer,headline,first-name,last-name,specialties,summary,industry,picture-url),num-results)?keywords=marketing&count=25&sort=relevance";
           var contacts = apiHit(url);
           var xml = new XmlDocument();
           xml.LoadXml(contacts);
           return deserialise(xml, new PeopleSeach());
        }

        private static void getIntro(Person person)
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

        private static T deserialise<T>(XmlDocument xml, T myResult)
        {

            var mySerializer = new XmlSerializer(myResult.GetType());
            var myStream = new MemoryStream();
            xml.Save(myStream);
            myStream.Position = 0;
            var r = mySerializer.Deserialize(myStream);
            return (T) r;

        }

        private static string apiHit(string endpoint)
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