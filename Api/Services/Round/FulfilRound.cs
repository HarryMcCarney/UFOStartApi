using System.Linq;
using DBVC;
using Model;
using UFOStart.Model;

namespace UFOStart.Api
{
    public static class FulfilRound
    {

        public static void assignServices(Round round)
        {
            var orm = new Orm();
            orm.execObject<Result>(round, "api.round_assign_services");
        }


        public static void assignExperts(Round round)
        {
            var orm = new Orm();
            var needs = (from x in  orm.execObject<Result>(round, "api.company_get_round").Needs where x.expert select x).ToList();

            foreach (var need in needs)
            {
                


            }



        }

    }
}