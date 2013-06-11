using System;
using System.Threading.Tasks;
using HackandCraft.Api;
using HackandCraft.Config;
using Model;
using UFOStart.Api.Services.Messaging;
using UFOStart.Model;
using mandrill.net;

namespace UFOStart.Api.Controllers
{
    public class CompanyController : HackandCraftController
    {
        public string template(Company company)
        {
            try
            {
                result = orm.execObject<Result>(company, "api.company_add_template");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string index(Company company)
        {
            try
            {
                result = orm.execObject<Result>(company, "api.company_get");


            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


        public string create(User user)
        {
            try
            {
                result = orm.execObject<Result>(user, "api.company_create");
                var myResult = (Result)result;
                if (myResult.User.Company.Round != null)
                {
                    new FulfilRound(myResult.User.Company.Round).fulfil();
                   // var task = new Task(() => new FulfilRound(myResult.User.Company.Round).fulfil());
                    //task.Start();
                }
                

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


        public string edit(User user)
        {
            try
            {
                result = orm.execObject<Result>(user, "api.company_create");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }



        public string angelList(Company company)
        {
            try
            {
                result = orm.execObject<Result>(company, "api.company_add_angel_list");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


        public string invite(Invites invites)
        {
            try
            {
                foreach (var invite in invites.Invite)
                {
                    var token = Guid.NewGuid().ToString();
                    invite.inviteToken = token;
                    result = orm.execObject<Result>(invite, "api.company_invite");
                    var link = string.Format("{0}{1}{2}", Globals.Instance.settings["RootUrl"],
                                             Globals.Instance.settings["CompanyInvite"], invite.inviteToken);
                    Mail.enqueue(new CompanyInviteEmail(invite.email, invite.name, invite.invitorName, link));
                }

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string getInvite(Invite invite)
        {
            try
            {
                result = orm.execObject<Result>(invite, "api.invite_get");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }



        public string acceptInvite(Invite invite)
        {
            try
            {
                result = orm.execObject<Result>(invite, "api.invite_accept");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

    }
}
