using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMMSReadEmail
{
    class FileProcessor
    {
        private System.Diagnostics.EventLog eventLog1; 
        FileSystemWatcher watcher;
        string directoryToWatch;
        public FileProcessor(string path)
        {
            this.watcher = new FileSystemWatcher();
            this.directoryToWatch = path;
            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("HmmsService"))
            {
                System.Diagnostics.EventLog.CreateEventSource("HmmsService", "HmmsServiceLog");
            }
            eventLog1.Source = "HmmsService";
            eventLog1.Log = "";
        }
        public void Watch()
        {
            eventLog1.WriteEntry("In Watch");
            watcher.Path = directoryToWatch;
            watcher.NotifyFilter = NotifyFilters.LastAccess |
                         NotifyFilters.LastWrite |
                         NotifyFilters.FileName |
                         NotifyFilters.DirectoryName;
            watcher.Filter = "*.*";
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            FileTypes.LogModel localLog = new FileTypes.LogModel();
            if (File.Exists(e.FullPath))
            {
                SendEmail mail = null; 
                eventLog1.WriteEntry("In OnChange - " + e.FullPath);
                // Wait 3 seconds.
                System.Threading.Thread.Sleep(3000);
                eventLog1.WriteEntry("In OnChange - Upload File");
                localLog.WriteLog("SUCCESS", "In OnChange - " + e.FullPath);
                UploadFiles upload = new UploadFiles();
                if (upload.LoadFiles(e.FullPath, eventLog1))
                {
                    //eventLog1.WriteEntry("In OnChange - Export File");
                    //ExportTables exportfiles = new ExportTables();
                    //if (exportfiles.CreateCSVfile(e.Name, eventLog1))
                    //    mail = new SendEmail("larry.dunn@aecom.com", "", "", "HMMS File Processed", " Load /Export File had been processed : " + e.Name, eventLog1);
                    //else
                    //    mail = new SendEmail("larry.dunn@aecom.com", "", "", "HMMS File Processed - Falid", "Exporting of the Files has Faild : " + e.Name, eventLog1);
                }
                else
                {
                    //mail = new SendEmail("larry.dunn@aecom.com", "", "", "HMMS File Processed - Falid", "Files have Faild check the HMMSLoad/Error Folder : " + e.Name, eventLog1);
                    localLog.WriteLog("ERROR", "In OnChange - " + e.FullPath);
                }
            }
        }
    }
}
