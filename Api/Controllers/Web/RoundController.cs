using System;
using System.Threading.Tasks;
using HackandCraft.Api;
using Model;
using UFOStart.Api.Services;
using UFOStart.Api.Services.Round;
using UFOStart.Model;
using HackandCraft.Config;
using UFOStart.Api.Services.Messaging;
using mandrill.net;

namespace UFOStart.Api.Controllers.Web
{
    public class RoundController : HackandCraftController
    {
      
        public string create(Company company)
        {
            try
            {
                result = orm.execObject<Result>(company, "api.company_round_create");
           
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }
        public string index(Round round)
        {
            try
            {
                result = orm.execObject<Result>(round, "api.company_get_round");
                
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


        public string needs(Round round)
        {
            try
            {
                var myResult = orm.execObject<Result>(round, "api.company_needs_create");
                new FulfilRound(myResult.Round).fulfil();
                orm.execObject<Result>(round, "api.find_experts_contacts");
                result = orm.execObject<Result>(myResult.Round, "api.company_get_round");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string removeNeed(Round round)
        {
            try
            {
                result = orm.execObject<Result>(round, "api.round_remove_need");
              }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string removeTag(Round round)
        {
            try
            {
                result = orm.execObject<Result>(round, "api.need_remove_tag");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string need(Round round)
        {
            try
            {
                result = orm.execObject<Result>(round, "api.round_need_edit");
                var myresult = (Result) result;
               // new FulfilRound(myresult.Round).fulfil();
                new Task(() => new FulfilRound(myresult.Round).fulfil()).Start();
                orm.execObject<Result>(round, "api.find_experts_contacts");
                if (round.Invite != null)
                {
                    foreach (var invite in round.Invite)
                    {
                        var token = Guid.NewGuid().ToString();
                        invite.inviteToken = token;
                        invite.Need.name = round.Needs[0].name;
                        result = orm.execObject<Result>(invite, "api.company_invite");
                        var link = string.Format("{0}{1}{2}", Globals.Instance.settings["RootUrl"],
                                                 Globals.Instance.settings["CompanyInvite"], invite.inviteToken);
                        Mail.enqueue(new InviteNeedEmail(invite.email, invite.name, invite.invitorName, invite.Need.name, myresult.Company.name, link));
                    }
                }
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string needCreate(Round round)
        {
            try
            {
                result = orm.execObject<Result>(round, "api.round_need_create");
                var myresult = (Result)result;
                new Task(() => new FulfilRound(myresult.Round).fulfil()).Start();
                orm.execObject<Result>(round, "api.find_experts_contacts");

                if (round.Invite != null)
                {
                    foreach (var invite in round.Invite)
                    {
                        var token = Guid.NewGuid().ToString();
                        invite.inviteToken = token;
                        invite.Need.name = round.Needs[0].name;
                        result = orm.execObject<Result>(invite, "api.company_invite");
                        var link = string.Format("{0}{1}{2}", Globals.Instance.settings["RootUrl"],
                                                 Globals.Instance.settings["CompanyInvite"], invite.inviteToken);
                        Mail.enqueue(new InviteNeedEmail(invite.email, invite.name, invite.invitorName, invite.Need.name, myresult.Company.name, link));
                    }
                }
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


        public string needAdd(Round round)
        {
            try
            {
                result = orm.execObject<Result>(round, "api.round_need_add");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string activity(Round round)
        {
            try
            {
                result = orm.execObject<Result>(round, "api.round_activity");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


        public string publish(Round round)
        {
            try
            {
                result = orm.execObject<Result>(round, "api.round_publish");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string sendMentor(Round round)
        {
            try
            {
                result = orm.execObject<Result>(round, "api.round_send_to_mentor");
                MessageHelpers.sendMentorRoundMail(((Result)result).Company);
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


        public string endorse(Need need)
        {
            try
            {
                result = CreateEndorsement.endorse(need);
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }



    }
}








