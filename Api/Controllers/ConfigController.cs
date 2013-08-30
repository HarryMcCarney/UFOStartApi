using HackandCraft.Api;
using System;

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
