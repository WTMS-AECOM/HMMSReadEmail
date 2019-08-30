namespace HMMSReadEmail
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.HMMSServiceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            this.HMMSServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // HMMSServiceProcessInstaller1
            // 
            this.HMMSServiceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.HMMSServiceProcessInstaller1.Password = null;
            this.HMMSServiceProcessInstaller1.Username = null;
            // 
            // HMMSServiceInstaller
            // 
            this.HMMSServiceInstaller.ServiceName = "HmmsService";
            this.HMMSServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.HMMSServiceProcessInstaller1,
            this.HMMSServiceInstaller});

        }

        #endregion

        public System.ServiceProcess.ServiceProcessInstaller HMMSServiceProcessInstaller1;
        public System.ServiceProcess.ServiceInstaller HMMSServiceInstaller;
    }
}