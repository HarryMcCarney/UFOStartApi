using HackandCraft.Config;
using Topshelf;
using mandrill.net;


namespace UFOStart.MailQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Config.Instance.apiUrl = @"https://mandrillapp.com/api/1.0/messages/send-template.json";
            Config.Instance.apiKey = @"GA51IwlzRHKI7fv1hd0x1Q";
            Config.Instance.dbConn = Globals.Instance.settings["MailQueueConnectionString"];
            Config.Instance.replyTo = @"support@ufostart.com";
           // Config.Instance.fromEmail = @"support@ufostart.com";
            //Config.Instance.fromName = @"UFO Start";

            HostFactory.Run(x =>
            {
                x.Service<QueueRunner>(s =>
                {
                    s.ConstructUsing(name => new QueueRunner());
                    s.WhenStarted(tc => tc.start());
                    s.WhenStopped(tc => tc.stop());
                });
                x.RunAsNetworkService();

                var serviceName = Globals.Instance.settings["MailQueueServiceName"];
                x.SetDescription(serviceName);
                x.SetDisplayName(serviceName);
                x.SetServiceName(serviceName);
            });                          


            Worker.run();
        }
    }
}
