using System;
using System.Globalization;
using System.IO;

namespace LinkedIn
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = testApi();

                Console.Write(test);
            Console.ReadLine();

        }

        private static string testApi()
        {
            string yelpSearchURL = "http://api.linkedin.com/v1/people-search";
            string yelpConsumerKey = "8qim4hatqh0z";
            string yelpConsumerSecret = "hSYEq3VJO9Ol82hw";
            string yelpRequestToken = "f54edfdb-ce02-411d-bd20-a2b20c2dd3d5";
            string yelpRequestTokenSecret = "8d2e1276-79dd-4bbf-bd52-2cb188a68db6";

            Twitterizer.OAuthTokens ot = new Twitterizer.OAuthTokens();
            ot.AccessToken = yelpRequestToken;
            ot.AccessTokenSecret = yelpRequestTokenSecret;
            ot.ConsumerKey = yelpConsumerKey;
            ot.ConsumerSecret = yelpConsumerSecret;

            string formattedUri = String.Format(CultureInfo.InvariantCulture,
                                 yelpSearchURL, "");
            Uri url = new Uri(formattedUri);
            Twitterizer.WebRequestBuilder wb = new Twitterizer.WebRequestBuilder(url, Twitterizer.HTTPVerb.GET, ot);
            System.Net.HttpWebResponse wr = wb.ExecuteRequest();
            StreamReader sr = new StreamReader(wr.GetResponseStream());
            return sr.ReadToEnd();
        }
    }
}
