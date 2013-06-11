using System;
using HackandCraft.Api;
using Model;

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
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

    }
}
