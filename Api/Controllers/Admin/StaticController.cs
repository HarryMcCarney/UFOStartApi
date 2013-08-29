using HackandCraft.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace UFOStart.Api.Controllers.Admin
{
    public class StaticController : HackandCraftController
    {
        //
        // GET: /Static/

        public string set(Content stat)
        {
            try
            {
                result = orm.execObject<Result>(stat, "api.admin_static_set");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string index()
        {
            try
            {
                result = orm.execObject<Result>(null, "api.admin_static_get");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

    }
}
