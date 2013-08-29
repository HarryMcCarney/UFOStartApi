using HackandCraft.Api;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UFOStart.Api.Controllers.Admin
{
    public class ServiceController : HackandCraftController
    {
        //
        // GET: /Service/

        public string create(Service service)
        {
            try
            {
                result = orm.execObject<Result>(service, "api.admin_service_create");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string all()
        {
            try
            {
                result = orm.execObject<Result>(null, "api.admin_services_get");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }



        public string edit(Service service)
        {
            try
            {
                result = orm.execObject<Result>(service, "api.admin_service_edit");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


    }
}
