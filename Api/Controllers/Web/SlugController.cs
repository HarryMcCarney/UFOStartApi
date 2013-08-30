using System;
using HackandCraft.Api;
using UFOStart.Model;

namespace UFOStart.Api.Controllers.Web
{
    public class SlugController : HackandCraftController
    {
        public string Index(User user)
        {
            try
            {
                result = orm.execObject<Result>(user, "api.get_slug_type");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

    }
}
