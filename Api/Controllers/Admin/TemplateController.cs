using HackandCraft.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UFOStart.Api.Controllers.Admin
{
    public class TemplateController : HackandCraftController
    {


        public string all()
        {
            try
            {
                result = orm.execObject<Result>(null, "api.admin_get_templates");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


       
    }
}
