using HackandCraft.Api;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UFOStart.Api.Controllers.Admin
{
    public class NeedController : HackandCraftController
    {
        //
        // GET: /Need/

        public string all()
        {
            try
            {
                result = orm.execObject<Result>(null, "api.admin_get_needs");

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
                result = orm.execObject<Result>(need, "api.admin_need_create");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string edit(Need need)
        {
            try
            {
                result = orm.execObject<Result>(need, "api.admin_need_edit");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string index(Need need)
        {
            try
            {
                result = orm.execObject<Result>(need, "api.admin_get_need");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

    }
}
