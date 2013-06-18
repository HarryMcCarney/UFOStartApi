using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using LinkedIn;
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

            var rawContacts = Contact.getContacts(_need, accessToken);
            if (rawContacts == null)
                return null;
            var contacts = (from x in rawContacts.People.Person where x.firstName != "private" select x).ToList();
            if (contacts.Count == 0)
                return null;
            rankContacts(contacts);


            var bestMatches = (from x in contacts orderby x.rating descending select x).Take(7).ToList();
            foreach (var match in bestMatches)
            {
                Contact.getIntro(match, accessToken);


                var expert = new Expert()
                    {

                        firstName = match.firstName,
                        lastName = match.lastName,
                        linkedinId = match.id,
                        picture = match.picture
                    };

                
                if (match.Intro != null)
                {
                    expert.introFirstName = match.Intro.firstName;
                    expert.introLastName = match.Intro.lastName;
                    expert.introLinkedinId = match.Intro.id;
                    expert.introPicture = Contact.getPicture(match.Intro.id,accessToken);
                };
                experts.Add(expert);

            }

            return experts;
        }

        private  void rankContacts(List<Person> contacts )
        {
            foreach (var c in contacts)
            {

                c.rating = -1;
            }
             contacts[0].rating = 100;
        }




       




       


    }

    
}
