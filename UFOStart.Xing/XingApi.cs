using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UFOStart.Xing
{
    public class XingApi
    {

        public static void get(string accessToken, string secret)
        {

            var oauth = new OAuth.Manager();
            oauth["token"] = "5ce2654e095a5ef75a8d";
            oauth["token_secret"] = secret;
            oauth["customer_key"] = "79652d927087ffc886e6";
            var authzHeader = oauth.GenerateAuthzHeader("https://api.xing.com/v1/users/me/contacts?limit=0", "GET");
            var request = (HttpWebRequest)WebRequest.Create("https://api.xing.com/v1/users/me/contacts?limit=0");
            request.Method = "POST";
            request.PreAuthenticate = true;
            request.AllowWriteStreamBuffering = true;
            request.Headers.Add("Authorization", authzHeader);

        }


    }
}
