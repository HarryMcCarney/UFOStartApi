using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBVC;
using LinkedIn;
using Model;
using UFOStart.Model;

namespace UFOStart.Api.Services
{
    public static class SaveSkills
    {

        public static void save(User user)
        {

            var orm  =  new Orm();
            var skills = Contact.getSkils(user.Profile[0].id, user.Profile[0].accessToken);

            if (skills == null) return;
            var userSkills = skills.Select(s => new Skill() {name = s}).ToList();
            user.Skills = userSkills;
            orm.execObject<Result>(user, "api.user_skills_save");
        }
    }
}