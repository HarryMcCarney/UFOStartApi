using System;
using DBVC;
using LinkedIn;
using Model;
using System.Collections.Generic;
using NLog;
using UFOStart.Model;

namespace UFOStart.Api.Services
{
    public class SaveConnections
    {
        public static readonly Logger log = LogManager.GetCurrentClassLogger();

        public static void save(User user)
        {
             try
            {
            var orm = new Orm();
            log.Warn("getting connnections from persons");
            var connections = Contact.getConnections(user.Profile[0].id, user.Profile[0].accessToken);
            log.Warn("got connection moving on");
            var ul = new List<User>();         
            foreach (var profile in connections.Persons)
            {
                ul.Add(new User());
                var p = new Profile();
                p.id = profile.ID.value;
                ul[ul.Count-1].Profile = new List<Profile>();
                ul[ul.Count - 1].Profile.Add(p); 

                log.Warn("getting profile from persons");
            }
            user.Users = ul;
            log.Warn("calling user_connections_save");
            orm.execObject<Result>(user, "api.user_connections_save");
            }

             catch (Exception exp)
             {
                 log.Error(exp);

             }
        }
    }
}