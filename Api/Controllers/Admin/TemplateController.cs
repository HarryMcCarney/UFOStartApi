using HackandCraft.Api;
using Model;
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

        public string create(Template template)
        {
            try
            {
                result = orm.execObject<Result>(template, "api.admin_template_create");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string edit(Template template)
        {
            try
            {
                result = orm.execObject<Result>(template, "api.admin_template_edit");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


       
    }
}
