using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Facebook;
using NLog;

namespace UFOStart.Facebook
{
    public static class FbApi
    {

            private static readonly Logger log = LogManager.GetCurrentClassLogger();


            public static List<UserFriend> friends(string accessToken)
            {
                try
                {
                    FacebookClient fbApi = new FacebookClient();
                    fbApi.AccessToken = accessToken;
                    dynamic result = fbApi.Get("/me/friends");
                    var friends = (
                        from dynamic friend
                            in (IList<object>) result["data"]
                        orderby friend.name ascending
                        select new UserFriend()
                        {
                            id = (string) friend.id,
                            name = (string) friend.name,
                            picture = (string) friend.picture
                        }
                        ).ToList();
                    return friends;
                }
                catch (Exception e)
                {                   
                    log.Error(String.Format("Facebook friends call went bad: {0}", e));
                    return null;
                }
            }

            public static string me(string accessToken)
            {
                try
                {
                    FacebookClient fbApi = new FacebookClient();
                    fbApi.AccessToken = accessToken;
                    dynamic result = fbApi.Get("/me");
                    return result["link"];
                }
                catch (Exception e)
                {
                    log.Error(String.Format("Facebook me call went bad: {0}", e));
                    return null;
                }
            }
    }
}
