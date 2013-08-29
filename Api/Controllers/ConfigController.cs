using HackandCraft.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UFOStart.Api.Controllers
{
    public class ConfigController : HackandCraftController
    {
        public string Index()
        {
            try
            {
                result = orm.execObject<Result>(null, "api.config");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

    }
}
