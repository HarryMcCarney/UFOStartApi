using System.Timers;
using NLog;
using mandrill.net;


namespace UFOStart.MailQueue
{
    class QueueRunner
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();
        readonly Timer _timer;
        public QueueRunner()
        {
            _timer = new Timer(10000) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) => process();
        }
        public void start() { _timer.Start(); }
        public void stop() { _timer.Stop(); }

        public void process()
        {
            log.Info("starting to process messages");
                Worker.run();


        }
            
    }
}
