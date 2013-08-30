using DBVC;
using LinkedIn;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UFOStart.Model;

namespace UFOStart.Api.Services
{
    public class SaveConnections
    {
        public static void save(User user)
        {
            var orm = new Orm();
            var connections = Contact.getConnections(user.Profile[0].id, user.Profile[0].accessToken);
            var ul = new List<User>();         
            foreach (var profile in connections.Persons)
            {
                ul.Add(new User());
                Profile p = new Profile();
                p.id = profile.ID.value;
                ul[ul.Count-1].Profile = new List<Profile>();
                ul[ul.Count - 1].Profile.Add(p); 
            }
            user.Users = ul;
            orm.execObject<Result>(user, "api.user_connections_save");
        }
    }
}