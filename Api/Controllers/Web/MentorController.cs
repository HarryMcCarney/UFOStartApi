using System;
using HackandCraft.Api;

namespace UFOStart.Api.Controllers.Web
{
    public class MentorController : HackandCraftController
    {

        public string top()
        {
            try
            {
                result = orm.execObject<Result>(null, "api.top_mentors");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

    }
}
