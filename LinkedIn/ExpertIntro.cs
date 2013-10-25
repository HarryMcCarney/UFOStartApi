using System.Collections.Generic;
using System.Linq;
using DBVC;
using HackandCraft.Config;
using LinkedIn;
using Model;
using UFOStart.Model;


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
            need = _need.name;

            var rawContacts = Contact.getContacts(_need, accessToken);
            if (rawContacts == null)
                return ;
            var contacts = (from x in rawContacts.People.Person where x.firstName != "private" select x).ToList();
            if (contacts.Count == 0)
                return ;
            rankContacts(contacts);


            var bestMatches = (from x in contacts orderby x.rating descending select x).Take(4).ToList();
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
                var skills = Contact.getSkils(match.id, accessToken);
                if (skills != null)
                {
                    
                     expert.Skills = skills.Select(s => new Model.Skill() { name = s }).ToList();
                }


          
                if (intro != null && intro.Intro != null)
                {
                    expert.introFirstName = intro.Intro.firstName;
                    expert.introLastName = intro.Intro.lastName;
                    expert.introLinkedinId = intro.Intro.id;
                    expert.introPicture = Contact.getPicture(intro.Intro.id, accessToken);
                };

                var experts = new List<Expert>();
                experts.Add(expert);
                _need.Experts = experts;
                _round.Needs = new List<Need>() { _need };

                new Orm().execObject<Result>(_round, "api.round_assign_experts");

            }

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
