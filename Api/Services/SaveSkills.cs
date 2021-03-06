﻿using System;
using System.Linq;
using DBVC;
using LinkedIn;
using Model;
using UFOStart.Model;
using NLog;

namespace UFOStart.Api.Services
{
    public static class SaveLinkedInDetails
    {
        public static readonly Logger log = LogManager.GetCurrentClassLogger();
        public static void save(User user)
        {
            try
            {

                var orm = new Orm();
                var skills = Contact.getSkils(user.Profile[0].id, user.Profile[0].accessToken);
                var headline = Contact.getHeadline(user.Profile[0].id, user.Profile[0].accessToken);
                var interests = Contact.getInterest(user.Profile[0].id, user.Profile[0].accessToken);
                if (skills == null) return;
                var userSkills = skills.Select(s => new Skill() {name = s}).ToList();
                user.Skills = userSkills;
                user.headline = headline;
                user.interests = interests;
                orm.execObject<Result>(user, "api.user_skills_save");
            }

            catch (Exception exp)
            {
                log.Error(exp);

            }
        }
    }
}