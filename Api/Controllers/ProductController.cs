using System;
using HackandCraft.Api;
using Model;

namespace UFOStart.Api.Controllers
{
    public class ProductController : HackandCraftController
    {
   
        public string create(Round round)
        {
            try
            {
                result = orm.execObject<Result>(round, "api.company_product_set");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string offer(Round round)
        {
            try
            {
                result = orm.execObject<Result>(round, "api.company_product_offers");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string newest()
        {
            try
            {
                result = orm.execObject<Result>(null, "api.product_search_newest");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

    }
}
