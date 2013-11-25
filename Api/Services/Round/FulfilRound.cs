using System.Linq;
using DBVC;
using Model;
using UFOStart.LinkedIn;
using UFOStart.Model;

namespace UFOStart.Api
{
    public  class FulfilRound
    {
        private readonly Round round;

        public FulfilRound(Round _round)
        {
            this.round = _round;
        }

        public  void fulfil()
        {
            //we do not want to assign services automatically anymore 
            //assignServices();
            assignExperts();
        }


        public  void assignServices()
        {
            var orm = new Orm();
            orm.execObject<Result>(round, "api.round_assign_services");
        }


        public  void assignExperts()
        {
            var orm = new Orm();
            var needs = (from x in orm.execObject<Result>(round, "api.company_get_round").Round.Needs where x.isExpert select x).ToList();
            var user = (from x in orm.execObject<Result>(round, "api.company_get_round").Round.Users select x).ToList()[0];
            foreach (var need in needs)
            {
                new ExpertIntro(round).getExperts(user, need);
             
            }
    

        }

    }
}