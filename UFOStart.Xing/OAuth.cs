using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json.Linq;

namespace UFOStart.Xing
{
    public class OAuth
    {
        private SortedDictionary<String, String> sd { get; set; }
        private string tokenSecret { get; set; }
        private string appSecret { get; set; }


        public OAuth(string token, string _tokenSecret, string appId, string _appSecret)
        {            
            tokenSecret = _tokenSecret;
            appSecret = _appSecret;         
            sd = new SortedDictionary<string, string>();
            sd.Add("oauth_token", token);
            sd.Add("oauth_consumer_key", appId);
            sd.Add("oauth_version", "1.0");
            sd.Add("oauth_timestamp", "");
            sd.Add("oauth_nonce", "");
        }

        public HttpWebResponse hmac(string url, string method)
        {

            sd["oauth_timestamp"] = nowSeconds();
            sd["oauth_nonce"] = randomString();
            if (sd.ContainsKey("oauth_signature_method"))
            {
                sd["oauth_signature_method"] = "HMAC-SHA1";
            }
            else
            {
                sd.Add("oauth_signature_method", "HMAC-SHA1");
            }
            var baseString = getBaseString();
            var textToCode = textForCode(url, method);
            var signature = getSignature(textToCode);

            var hwr = (HttpWebRequest)WebRequest.Create(String.Format("{0}?{1}oauth_signature={2}", url, baseString, signature));
            hwr.Method = method;
            hwr.Timeout = 3 * 60 * 1000;
          
            return hwr.GetResponse() as HttpWebResponse;
           
        }


        public HttpWebResponse plainText(string url, string method)
        {

            sd["oauth_timestamp"] = nowSeconds();
            sd["oauth_nonce"] = randomString();
            if (sd.ContainsKey("oauth_signature_method"))
            { 
                sd["oauth_signature_method"] = "PLAINTEXT";
            }
            else
            {
                sd.Add("oauth_signature_method", "PLAINTEXT");
            }
            var baseString = getBaseString();
            var signature = Uri.EscapeDataString(appSecret) + Uri.EscapeDataString("&") +
                    Uri.EscapeDataString(tokenSecret);
            var hwr =(HttpWebRequest)
                        WebRequest.Create(String.Format("{0}?{1}oauth_signature={2}", url, baseString, signature));
            hwr.Method = method;
            hwr.Timeout = 3*60*1000;

            return hwr.GetResponse() as HttpWebResponse;
            
        }

        private static string randomString()
        {
            return Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
        }

        private string nowSeconds()
        {
            TimeSpan ts = DateTime.UtcNow -
               new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc
           );

            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        private string getBaseString()
        {
            var baseString = String.Empty;
            foreach (KeyValuePair<string, string> entry in sd)
            {
                baseString += String.Format("{0}={1}&", entry.Key, entry.Value);
            }
            return baseString;
        }

        private string textForCode( string url,string method)
        {

            string codeString = String.Format("{0}&{1}&", method.ToUpper(), Uri.EscapeDataString(url));
            string vars = String.Empty;
            foreach (KeyValuePair<string, string> entry in sd)
            {
                vars += Uri.EscapeDataString(entry.Key) + "=" + Uri.EscapeDataString(entry.Value) + "&";
            }
            vars = vars.Substring(0, vars.Length - 1);

            return codeString + Uri.EscapeDataString(vars);

        }

        private string getSignature(string codeString)
        {
            var signingKey =
                    Uri.EscapeDataString(appSecret) + "&" +
                    Uri.EscapeDataString(tokenSecret);

            var hmacsha1 = new HMACSHA1
            {
                Key = System.Text.Encoding.ASCII.GetBytes(signingKey)
            };

            byte[] dataBuffer = System.Text.Encoding.ASCII.GetBytes(codeString);
            byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);

            return Convert.ToBase64String(hashBytes);

        }
    }
}
