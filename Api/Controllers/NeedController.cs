using System;
using System.Linq;
using HackandCraft.Api;
using Model;
using UFOStart.Api.Services;

namespace UFOStart.Api.Controllers
{
    public class NeedController : HackandCraftController
    {
        public string list()
        {
            try
            {
                result = orm.execObject<Result>(null, "api.user_get_needs");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string create(Need need)
        {
            try
            {
                result = orm.execObject<Result>(need, "api.need_create");
               
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string application(Need need)
        {
            try
            {
                result = orm.execObject<Result>(need, "api.need_application");

                //wanna get need name and applicant name fro the result
                //so first find the rigth need and then the right applicant

                //Get need
                var fullNeed = (from x in ((Result) result).Round.Needs
                               where x.token == need.token
                               select x).ToList()[0];

                var application = (from x in ((Need) fullNeed).Applications
                                  where x.User.token == need.Application.User.token
                                  select x).ToList()[0];

                need.name = fullNeed.name;
                need.Application.User.name = application.User.name;


                MessageHelpers.senderFoundApplicationMail(result, need);


            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string approveApplication(Application application)
        {
            try
            {
                result = orm.execObject<Result>(application, "api.need_application_approve");
                var user = ((Result) result).User;
                var myapplication = ((Result) result).Application;
                MessageHelpers.senderApplicationAcceptedmail(user, myapplication);

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string search(Search search)
        {
            try
            {
                result = orm.execObject<Result>(search, "api.need_search");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


        public string popular()
        {
            try
            {
                result = orm.execObject<Result>(null, "api.need_search_popular");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string location()
        {
            try
            {
                result = orm.execObject<Result>(null, "api.need_search_location");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string invite(Invite invite)
        {
            try
            {
                MessageHelpers.inviteToNeedMail(invite);
                
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }
    }
}
