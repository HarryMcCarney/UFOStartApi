using System.Linq;
using HackandCraft.Config;
using UFOStart.Model;
using mandrill.net;

namespace UFOStart.Api.Services.Messaging
{
    public static class MessageHelpers
    {
        public static void sendMentorRoundMail(Company company)
        {

            var mentor = (from x in company.Users where x.role == "MENTOR" select x).Take(1).ToList()[0];

            var email = mentor.email;
            var name = mentor.name;
            var companyName = company.name;
            var roundLink = string.Format("{0}{1}{2}", Globals.Instance.settings["RootUrl"], Globals.Instance.settings["CompanyRoute"], company.slug);

            Mail.enqueue(new MentorApproveEmail(email, name, companyName, roundLink));
        }

    }
}