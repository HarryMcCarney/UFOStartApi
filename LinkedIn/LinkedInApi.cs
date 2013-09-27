using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using NLog;

namespace LinkedIn
{
    public  class LinkedInApi
    {
        public static readonly Logger log = LogManager.GetCurrentClassLogger();
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
            log.Warn("calling user_connections_save");
                var webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                return webClient.DownloadString(endpoint);
            
           
        }
    }
}
