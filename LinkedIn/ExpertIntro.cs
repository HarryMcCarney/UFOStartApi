using System.Collections.Generic;
using System.Linq;
using DBVC;
using HackandCraft.Config;
using LinkedIn;
using Model;
using UFOStart.Model;
using System;

namespace UFOStart.LinkedIn
{
    public class ExpertIntro
    {
        private readonly Round _round;


        public ExpertIntro(Round round )
        {
            _round = round;
        }

        private  string accessToken { get; set; }
        private  string secret { get; set; }
        private  string need { get; set; }


        public  void getExperts(User user, Need _need)
        {

            
            var profile = (from x in user.Profile where x.type == "LI" select x).Take(1).ToList()[0];
            accessToken = profile.accessToken;
            need = String.Empty;
            foreach (var t in _need.Tags){
                need = String.Format("{0}{1} OR ", need, t.name);
            }
            need = Uri.EscapeDataString(need.Remove(need.Length - 4));
            
            var rawContacts = Contact.getContacts(need, accessToken);
            if (rawContacts == null)
                return ;
            var contacts = (from x in rawContacts.People.Person where x.firstName != "private" select x).ToList();
            if (contacts.Count == 0)
                return ;
            rankContacts(contacts);

            var bestMatches = (from x in contacts orderby x.rating descending select x).Take(4).ToList();
            var experts = new List<Expert>();
            foreach (var match in bestMatches)
            {
                var intro = Contact.getIntro(match, accessToken);


                var expert = new Expert()
                    {

                        firstName = match.firstName,
                        lastName = match.lastName,
                        linkedinId = match.id,
                        picture = match.picture,
                        headline = match.headline,
                       
                    };

                //we do not save this information so it makes it a redundand api call. Also lambda operator in this expression is not allowed.
                /*var skills = Contact.getSkils(match.id, accessToken);               
                if (skills != null)
                {
                    
                     expert.Skills = skills.Select(s => new Model.Skill() { name = s }).ToList();
                }*/


          
                if (intro != null && intro.Intro != null)
                {
                    expert.introFirstName = intro.Intro.firstName;
                    expert.introLastName = intro.Intro.lastName;
                    expert.introLinkedinId = intro.Intro.id;
                    expert.introPicture = Contact.getPicture(intro.Intro.id, accessToken);
                };

               
                experts.Add(expert);           
            }

               _need.Experts = experts;
                _round.Needs = new List<Need>() { _need };

                new Orm().execObject<Result>(_round, "api.round_assign_experts");

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
