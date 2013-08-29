using HackandCraft.Api;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UFOStart.Api.Controllers.Web
{
    public class ServiceController : HackandCraftController
    {
        //
        // GET: /Service/
        public string search(Service service)
        {
            try
            {
                result = orm.execObject<Result>(service, "api.service_search");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


    }
}
