using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace HMMSReadEmail
{
    class ExportTables
    {

        private string BatFileName = System.Configuration.ConfigurationManager.AppSettings["BatFileName"];
        public struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public uint dwProcessId;
            public uint dwThreadId;
        }

        public struct STARTUPINFO
        {
            public uint cb;
            public string lpReserved;
            public string lpDesktop;
            public string lpTitle;
            public uint dwX;
            public uint dwY;
            public uint dwXSize;
            public uint dwYSize;
            public uint dwXCountChars;
            public uint dwYCountChars;
            public uint dwFillAttribute;
            public uint dwFlags;
            public short wShowWindow;
            public short cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }

        public struct SECURITY_ATTRIBUTES
        {
            public int length;
            public IntPtr lpSecurityDescriptor;
            public bool bInheritHandle;
        }

        [DllImport("kernel32.dll")]
        static extern bool CreateProcess(string lpApplicationName, string lpCommandLine, IntPtr lpProcessAttributes, IntPtr lpThreadAttributes,
                        bool bInheritHandles, uint dwCreationFlags, IntPtr lpEnvironment,
                        string lpCurrentDirectory, ref STARTUPINFO lpStartupInfo, out PROCESS_INFORMATION lpProcessInformation);


        public Boolean CreateCSVfile(string fileName, System.Diagnostics.EventLog eventLog1)
        {
            try
            {
                STARTUPINFO si = new STARTUPINFO();
                PROCESS_INFORMATION pi = new PROCESS_INFORMATION();

                if (fileName.Contains("INV"))
                    System.Diagnostics.Process.Start(BatFileName, "INV");
                if (fileName.Contains("ISU"))
                    System.Diagnostics.Process.Start(BatFileName, "ISU");
                if (fileName.Contains("MXQ"))
                {
                    eventLog1.WriteEntry("In CreateCSVfile - Before BAT File");
                    //System.Diagnostics.Process ttt = System.Diagnostics.Process.Start(BatFileName, "MXQ");
                    if (CreateProcess(BatFileName + " MXQ", null, IntPtr.Zero, IntPtr.Zero, false, 0, IntPtr.Zero, null, ref si, out pi))
                        eventLog1.WriteEntry("In CreateCSVfile - After BAT File : Success");
                    else
                        eventLog1.WriteEntry("In CreateCSVfile - After BAT File : Faild");
                }
                if (fileName.Contains("NOP"))
                    System.Diagnostics.Process.Start(BatFileName, "NOP");
                if (fileName.Contains("ORD"))
                    System.Diagnostics.Process.Start(BatFileName, "ORD");
                if (fileName.Contains("QOH"))
                    System.Diagnostics.Process.Start(BatFileName, "QOH");
                if (fileName.Contains("TRN"))
                    System.Diagnostics.Process.Start(BatFileName, "TRN");
                return true;
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("In CreateCSVfile - " + ex.Message);
                return false;
            }
        }              
    }
}
