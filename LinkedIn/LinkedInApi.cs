using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Serialization;

namespace LinkedIn
{
    public  class LinkedInApi
    {
        public  T deserialise<T>(XmlDocument xml, T myResult)
        {

            var mySerializer = new XmlSerializer(myResult.GetType());
            var myStream = new MemoryStream();
            xml.Save(myStream);
            myStream.Position = 0;
            var r = mySerializer.Deserialize(myStream);
            return (T)r;

        }

        public  string hit(string endpoint)
        {
            
                var webClient = new WebClient();
                return webClient.DownloadString(endpoint);
            
           
        }
    }
}
