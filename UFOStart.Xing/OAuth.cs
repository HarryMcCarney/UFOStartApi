using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json.Linq;

namespace UFOStart.Xing
{
    /*
     * In general, we create a dictionary, that holds constant information.
     * With this, we can always build request parametrs, just timestamp
     * and nonce(random string) have to be updated before every request).    
    */
    public class OAuth
    {
        private SortedDictionary<String, String> sd { get; set; }
        private string tokenSecret { get; set; }
        private string appSecret { get; set; }

        //setup basic information that never changes

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
        //use HMAC-SHA1 method. Function accepts api url and method(GET,POST,...) and return response as JSON.
        public JObject hmac(string url, string method)
        {
            //update timestamp to now and generate random string from current time
            sd["oauth_timestamp"] = nowSeconds();
            sd["oauth_nonce"] = randomString();
            //chek if signature method has been set before to something else
            if (sd.ContainsKey("oauth_signature_method"))
            {
                sd["oauth_signature_method"] = "HMAC-SHA1";
            }
            else
            {
                sd.Add("oauth_signature_method", "HMAC-SHA1");
            }
            //get base string
            var baseString = getBaseString();
            //get text that will be coded
            var textToCode = textForCode(url, method);
            //code text
            var signature = getSignature(textToCode);
            //get response
            var response = JObject.Parse(new WebClient().DownloadString(String.Format("{0}?{1}oauth_signature={2}", url, baseString, signature)));

            return response;
        }

        //use PLANTEXT method. Function accepts api url and method(GET,POST,...) and return response as JSON.
        public JObject plainText(string url, string method)
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
            //this time, we do not code anything, cause we are using plain text method, just merge the keys together, with & in between

            var signature = Uri.EscapeDataString(appSecret) + Uri.EscapeDataString("&") +
                    Uri.EscapeDataString(tokenSecret);
            //get resonse
            var response = JObject.Parse(new WebClient().DownloadString(String.Format("{0}?{1}oauth_signature={2}", url, baseString, signature)));

            return response;         
        }

        //random string is created fro curent time
        private static string randomString()
        {
            return Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
        }

        //this gives us time in miliseconds from 1.1.1970
        private string nowSeconds()
        {
            TimeSpan ts = DateTime.UtcNow -
               new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc
           );

            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        //get the basic string (this will be used for paramethers, so at this point we can put everythin it to this form key=value&key=value....we finish off with &, because we need to append signature to it later
        private string getBaseString()
        {
            var baseString = String.Empty;
            foreach (KeyValuePair<string, string> entry in sd)
            {
                baseString += String.Format("{0}={1}&", entry.Key, entry.Value);
            }
            return baseString;
        }

        //createing text what we will encode with our secret. It is similar to base string, but we need to decoded and put in in this form GET&url_base&parametrs
        private string textForCode( string url,string method)
        {

            string codeString = String.Format("{0}&{1}&", method.ToUpper(), Uri.EscapeDataString(url));
            string vars = String.Empty;
            foreach (KeyValuePair<string, string> entry in sd)
            {
                vars += Uri.EscapeDataString(entry.Key) + "=" + Uri.EscapeDataString(entry.Value) + "&";
            }
            //taking away the last &, cause there is one to much (on the end)
            vars = vars.Substring(0, vars.Length - 1);

            return codeString + Uri.EscapeDataString(vars);

        }

        //we create a signature for signing we use appSecert + tokenSecert
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
