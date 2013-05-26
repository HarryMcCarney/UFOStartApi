using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HackandCraft.Api;
using Model;
using UFOStart.LinkedIn;
using UFOStart.Model;

namespace UFOStart.Api.Controllers
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

    }
}
