using System;
using HackandCraft.Api;
using Model;

namespace UFOStart.Api.Controllers.Web
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

        public string offerDelete(Offer offer)
        {
            try
            {
                result = orm.execObject<Result>(offer, "api.company_product_offer_delete");
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
