using System.Linq;
using DBVC;
using HackandCraft.Config;
using Model;
using UFOStart.Api.Services.Messaging;
using UFOStart.Model;
using mandrill.net;
using Round = Model.Round;


namespace UFOStart.Api.Services
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



        public static void senderFoundApplicationMail(IResult result, Need need)
        {
            var round = ((Result)result).Round;
            var orm = new Orm();
            var company = orm.execObject<Result>(round, "api.company_get_from_round").Company;
            var roundLink = string.Format("{0}{1}{2}", Globals.Instance.settings["RootUrl"], Globals.Instance.settings["CompanyRoute"], company.slug);
            var founders =
                 (from x in company.Users
                  where x.role == "FOUNDER"
                  select x).ToList();

            foreach (var f in founders)
            {
                Mail.enqueue(new ApplicationFounderEmail(f.email,f.name,need.name,need.Application.User.name,roundLink));
            }
        }

    }
}