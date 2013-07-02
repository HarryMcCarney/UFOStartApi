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
            //todo this is very dirty
            var roundLink = string.Format("{0}{1}{2}/1/", Globals.Instance.settings["RootUrl"], Globals.Instance.settings["CompanyRoute"], company.slug);

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
                  && !x.unconfirmed
                  select x).ToList();

            foreach (var f in founders)
            {
                Mail.enqueue(new ApplicationFounderEmail(f.email,f.name,need.name,need.Application.User.name,roundLink));
            }
        }


        public static void senderApplicationAcceptedmail(User user, Application application)
        {
            var roundLink = string.Format("{0}{1}{2}/1/{3}", Globals.Instance.settings["RootUrl"], Globals.Instance.settings["CompanyRoute"], application.companySlug, application.needSlug);
            Mail.enqueue(new ApplicationAcceptedEmail(user.email, user.name, application.need, application.companyName, roundLink));
            
        }

    }
}