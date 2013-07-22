using System.Collections.Generic;
using System.Linq;
using DBVC;
using HackandCraft.Config;
using LinkedIn;
using UFOStart.LinkedIn;
using UFOStart.Model;

namespace StartupValue
{
    public class UserStartupValue
    {
        private readonly User user;
        public int startUpValue { get; set; }
        private Person person { get; set; }

        public UserStartupValue(User _user)
        {
            user = _user;
            getLinkedinPerson();
        }

        private void getLinkedinPerson()
        {

            var id = (from x in user.Profile where x.type == "LI" select x).ToList()[0].id;
            var accessToken = (from x in user.Profile where x.type == "LI" select x).ToList()[0].accessToken;
            person = Contact.getPerson(id, accessToken);
        }

        public int calculate()
        {
            calculateCompanies();
            calculateSkills();
            calculateContacts();
            calculateInterests();
            return startUpValue;

        }

        public void save()
        {
            user.startupValue = calculate();

            var orm = new Orm();
            orm.execObject<Result>(user, "api.user_startup_value");

        }

        private void calculateCompanies()
        {
            startUpValue += person.positions * 1000;
        }

        private void calculateSkills()
        {
            if (person.skillTags != null)
                startUpValue += person.skillTags.Count * 1000;
        }

        private void calculateInterests()
        {
            if (person.interests != null)
                startUpValue += new List<string>(person.interests.Split(',')).Count * 1000;
        }

        private void calculateContacts()
        {
            startUpValue += person.Connections.total;

        }










    }
}
