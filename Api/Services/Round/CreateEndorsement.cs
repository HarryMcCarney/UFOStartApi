using System.Linq;
using DBVC;
using LinkedIn;
using Model;
using UFOStart.Model;

namespace UFOStart.Api.Services.Round
{
    public static class CreateEndorsement
    {
        public static Result endorse(Need need)
        {
            
            var orm = new Orm();
            var user = new User() {token = need.Endorsement.endorserToken};


            var accessToken = (from x in orm.execObject<Result>(user, "api.user_profile").User.Profile where x.type == "LI" select x).ToList()[0].accessToken;
            var skills = Contact.getSkils(need.Endorsement.endorseeLinkedinId, accessToken);
            if (skills != null)
                need.Endorsement.endorseeSkills = string.Join(",", skills.ToArray());
            var result = orm.execObject<Result>(need, "api.round_endorsement");
            return result;
        }

    }
}