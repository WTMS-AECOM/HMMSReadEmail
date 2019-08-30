using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace HMMSReadEmail
{
    public partial class HmmsService : ServiceBase
    {
        private int eventId = 1;
        private string emailAddress = System.Configuration.ConfigurationManager.AppSettings["EmailAddress"];
        public HmmsService()
        {
            InitializeComponent();
            //CancellationToken token = new CancellationToken();
            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("HmmsService"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "HmmsService", "HmmsServiceLog");
            }
            eventLog1.Source = "HmmsService";
            eventLog1.Log = "";
        }
        
        protected override void OnStart(string[] args)
        {
            string DirName = System.Configuration.ConfigurationManager.AppSettings["ReadDir"];
            FileTypes.LogModel log = new FileTypes.LogModel();
            log.WriteLog("SUCCESS", "ON-Start");
            // Set up a timer that triggers every minute.
            //System.Timers.Timer timer = new System.Timers.Timer();
            //timer.Interval = 60000; // 60 seconds
            //timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            //timer.Start();
            eventLog1.WriteEntry("In OnStart.");
            FileProcessor fp = new FileProcessor(DirName);
            fp.Watch();
        }

        protected override void OnStop()
        {
            FileTypes.LogModel log = new FileTypes.LogModel();
            log.WriteLog("SUCCESS", "ON-Stop");
            eventLog1.WriteEntry("In OnStop.");
        }
        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.
            eventLog1.WriteEntry("Monitoring the System", EventLogEntryType.Information, eventId++);
            //ExchangeServices.GetIncomingEmails(emailAddress);
        }
    }
}
