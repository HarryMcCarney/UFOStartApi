using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HackandCraft.Api;
using UFOStart.Model;

namespace UFOStart.Api.Controllers
{
    public class CompanyController : HackandCraftController
    {
        public string template(Company company)
        {
            try
            {
                result = orm.execObject<Result>(company, "api.company_add_template");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string index(Company company)
        {
            try
            {
                result = orm.execObject<Result>(company, "api.company_get");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


        public string create(User user)
        {
            try
            {
                result = orm.execObject<Result>(user, "api.company_create");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string angelList(Company company)
        {
            try
            {
                result = orm.execObject<Result>(company, "api.company_add_angel_list");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

    }
}
