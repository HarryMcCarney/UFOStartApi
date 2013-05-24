using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mandrill.net;

namespace UFOStart.MailQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Config.Instance.apiUrl = @"https://mandrillapp.com/api/1.0/messages/send-template.json";
            Config.Instance.apiKey = @"GA51IwlzRHKI7fv1hd0x1Q";
            Config.Instance.dbConn = @"data source=88.198.7.228\Descartes,1984;Initial Catalog=ufo_Dev;User Id=ufo_user;Password=Popov2010;";
            Config.Instance.replyTo = @"support@ufostart.com";
            Config.Instance.fromEmail = @"support@ufostart.com";
            Config.Instance.fromName = @"UFO Start";



            Worker.run();
        }
    }
}
