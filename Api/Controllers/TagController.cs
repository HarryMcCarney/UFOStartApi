using System;
using HackandCraft.Api;
using Model;

namespace UFOStart.Api.Controllers
{
    public class TagController : HackandCraftController
    {
        public string search(Tag tag)
        {
            try
            {
                result = orm.execObject<Result>(tag, "api.tag_search");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string top20(Tag tag)
        {
            try
            {
                result = orm.execObject<Result>(tag, "api.tag_top_20");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

    }
}
