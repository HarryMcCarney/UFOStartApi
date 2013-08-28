using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HackandCraft.Api;
using Model;

namespace UFOStart.Api.Controllers.Web
{
    public class PledgeController : HackandCraftController
    {
   
        public string create(Round round)
        {
         try
            {
                result = orm.execObject<Result>(round, "api.pledge_create ");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

    }
}
