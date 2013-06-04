using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HackandCraft.Api;

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

    }
}
