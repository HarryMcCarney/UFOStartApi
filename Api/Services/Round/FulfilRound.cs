using System.Linq;
using DBVC;
using Model;
using UFOStart.LinkedIn;
using UFOStart.Model;

namespace UFOStart.Api
{
    public static class FulfilRound
    {

        public static void fulfil(Round round)
        {
            assignServices(round);
            assignExperts(round);
        }

        public static void assignServices(Round round)
        {
            var orm = new Orm();
            orm.execObject<Result>(round, "api.round_assign_services");
        }


        public static void assignExperts(Round round)
        {
            var orm = new Orm();
            var needs = (from x in  orm.execObject<Result>(round, "api.company_get_round").Round.Needs where x.expert select x).ToList();
            var user = (from x in orm.execObject<Result>(round, "api.company_get_round").Round.Users select x).ToList()[0];
            foreach (var need in needs)
            {
                var expert = new ExpertIntro().getExpert(user, need);



            }



        }

    }
}