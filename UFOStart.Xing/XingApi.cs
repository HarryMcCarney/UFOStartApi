using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;

namespace UFOStart.Xing
{
    public class XingApi
    {

        private OAuth oa { get; set; }

        public XingApi(string token, string tokenSecret, string appId, string appSecret)
        {
            oa = new OAuth(token, tokenSecret, appId, appSecret);
        }


        public int getContactsNumber()
        {
            try
            {
                var res = oa.hmac("https://api.xing.com/v1/users/me/contacts", "get");
                var readStream = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                var o = JObject.Parse(readStream.ReadToEnd());
                return int.Parse((string)o["contacts"]["total"]);
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public string getProfileLink()
        {
            try
            {
                var res = oa.hmac("https://api.xing.com/v1/users/me", "get");
                var readStream = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                var o = JObject.Parse(readStream.ReadToEnd());

                return (string)o["users"][0]["permalink"];
            }
            catch (Exception e)
            {

                return "";
            }
        }
    }
}
