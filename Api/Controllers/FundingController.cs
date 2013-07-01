using System;
using HackandCraft.Api;
using Model;

namespace UFOStart.Api.Controllers
{
    public class FundingController : HackandCraftController
    {
        public string create(Round round)
        {
            try
            {
                result = orm.execObject<Result>(round, "api.round_funding_target");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string invest(Round round)
        {
            try
            {
                result = orm.execObject<Result>(round, "api.round_funding_invest");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

    }
}
