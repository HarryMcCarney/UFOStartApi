using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HackandCraft.Api;
using Model;

namespace UFOStart.Api.Controllers.Web
{
    public class TemplateController : HackandCraftController
    {
        
        public string index(Template template)
        {
            try
            {
                result = orm.execObject<Result>(template, "api.user_get_template_needs");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string list()
        {
            try
            {
                result = orm.execObject<Result>(null, "api.user_get_templates");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

    }
}
