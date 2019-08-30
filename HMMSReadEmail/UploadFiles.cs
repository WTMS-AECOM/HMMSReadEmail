using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HMMSReadEmail
{
    class UploadFiles
    {
        private FileInfo[] files;
        public FileInfo[] Files { get => files; set => files = value; }

        private string DirName = System.Configuration.ConfigurationManager.AppSettings["ReadDir"];
        private string ErrorFolder = System.Configuration.ConfigurationManager.AppSettings["ErrorFolder"];
        private string ProcessFolder = System.Configuration.ConfigurationManager.AppSettings["ProcessFolder"];
        private FileTypes.LogModel localLog = new FileTypes.LogModel();
        public UploadFiles()
        {
            DirectoryInfo d = new DirectoryInfo(DirName);        //Assuming Test is your Folder
            Files = d.GetFiles("*.xls");         //Getting Text files            
        }
        public string GetSheetName(string FileName, System.Diagnostics.EventLog eventLog1)
        {
            OleDbConnection objConn = null;
            System.Data.DataTable dt = null;
            string sheetname;
            try
            {
                    // Connection String. Change the excel file to the file you
                    // will search.
                    String connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + FileName + ";Extended Properties=Excel 8.0;";
                if (FileName.ToUpper().Contains(".XLS"))
                    connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties='Excel 12.0 XML;HDR=Yes'";
                // Create connection object by using the preceding connection string.
                objConn = new OleDbConnection(connString);
                // Open connection with the database.
                objConn.Open();
                // Get the data table containg the schema guid.
                dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (dt != null)
                {
                    if (FileName.ToUpper().Contains(".XLSB"))
                        sheetname = dt.Rows[1]["TABLE_NAME"].ToString();                    
                    else
                        sheetname = dt.Rows[0]["TABLE_NAME"].ToString();
                    if (sheetname.Contains("Filter"))
                        sheetname = dt.Rows[0]["TABLE_NAME"].ToString();
                    return sheetname.Replace("$", "").Replace("\'", "");
                }
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("In UploadFiles - " + ex.Message);
                return null;
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
            }
            return null;
        }

        public Boolean  LoadFiles(string FullName, System.Diagnostics.EventLog eventLog1)
        {
            try
            {
                DataSet localData = null;
                string sheetName;
                string fileName = Path.GetFileName(FullName);

                if (fileName.ToUpper().Contains(".XLS"))
                {
                    sheetName = GetSheetName(FullName, eventLog1);
                    localData = GetExcelData(FullName, sheetName, true);
                }

                if (fileName.Contains("AUL"))
                {
                    FileType.AULModel aulmodel = new FileType.AULModel();
                    if (!validate(localData, aulmodel.AULlist))
                    {
                        System.IO.File.Move(FullName, ErrorFolder + @"\" + fileName);
                    }
                    else
                    {
                        if (!aulmodel.loadData(localData))
                            System.IO.File.Move(FullName, ErrorFolder + @"\" + fileName);
                        else
                            System.IO.File.Move(FullName, ProcessFolder + @"\" + fileName);
                    }
                }
                if (fileName.Contains("MXQ"))
                {
                    FileType.MXQModel mxqmodel = new FileType.MXQModel();
                    if (!validate(localData, mxqmodel.MXQlist))
                    {
                        System.IO.File.Move(FullName, ErrorFolder + @"\" + fileName);
                    }
                    else
                    {
                        if (!mxqmodel.loadData(localData))
                            System.IO.File.Move(FullName, ErrorFolder + @"\" + fileName);
                        else
                            System.IO.File.Move(FullName, ProcessFolder + @"\" + fileName);
                    }
                }
                if (fileName.Contains("INV"))
                {
                    FileType.INVModel invmodel = new FileType.INVModel();
                    if (!validate(localData, invmodel.INVlist))
                    {
                        System.IO.File.Move(FullName, ErrorFolder + @"\" + fileName);
                    }
                    else
                    {
                        if (!invmodel.loadData(localData))
                            System.IO.File.Move(FullName, ErrorFolder + @"\" + fileName);
                        else
                            System.IO.File.Move(FullName, ProcessFolder + @"\" + fileName);
                    }
                }
                if (fileName.Contains("ISU"))
                {
                    FileType.ISUModel isumodel = new FileType.ISUModel();
                    if (!validate(localData, isumodel.ISUlist))
                    {
                        System.IO.File.Move(FullName, ErrorFolder + @"\" + fileName);
                    }
                    else
                    {
                        if (!isumodel.loadData(localData))
                            System.IO.File.Move(FullName, ErrorFolder + @"\" + fileName);
                        else
                            System.IO.File.Move(FullName, ProcessFolder + @"\" + fileName);
                    }
                }
                if (fileName.Contains("NOP"))
                {
                    FileType.NOPModel nopmodel = new FileType.NOPModel();
                    if (!validate(localData, nopmodel.NOPlist))
                    {
                        System.IO.File.Move(FullName, ErrorFolder + @"\" + fileName);
                    }
                    else
                    {
                        if (!nopmodel.loadData(localData))
                            System.IO.File.Move(FullName, ErrorFolder + @"\" + fileName);
                        else
                            System.IO.File.Move(FullName, ProcessFolder + @"\" + fileName);
                    }
                }
                if (fileName.Contains("ORD"))
                {
                    FileType.ORDModel ordmodel = new FileType.ORDModel();
                    if (!validate(localData, ordmodel.ORDlist))
                    {
                        System.IO.File.Move(FullName, ErrorFolder + @"\" + fileName);
                    }
                    else
                    {
                        if (!ordmodel.loadData(localData))
                            System.IO.File.Move(FullName, ErrorFolder + @"\" + fileName);
                        else
                            System.IO.File.Move(FullName, ProcessFolder + @"\" + fileName);
                    }
                }
                if (fileName.Contains("QOH"))
                {
                    FileType.QOHModel qohmodel = new FileType.QOHModel();
                    if (!validate(localData, qohmodel.QOHlist))
                    {
                        System.IO.File.Move(FullName, ErrorFolder + @"\" + fileName);
                    }
                    else
                    {
                        if (!qohmodel.loadData(localData))
                            System.IO.File.Move(FullName, ErrorFolder + @"\" + fileName);
                        else
                            System.IO.File.Move(FullName, ProcessFolder + @"\" + fileName);
                    }
                }
                if (fileName.Contains("TRN"))
                {
                    FileType.TRNModel trmmodel = new FileType.TRNModel();
                    if (!validate(localData, trmmodel.TRNlist))
                    {
                        System.IO.File.Move(FullName, ErrorFolder + @"\" + fileName);
                    }
                    else
                    {
                        if (!trmmodel.loadData(localData))
                            System.IO.File.Move(FullName, ErrorFolder + @"\" + fileName);
                        else
                            System.IO.File.Move(FullName, ProcessFolder + @"\" + fileName);
                    }
                }
                return true;
            }
            catch (IOException ex)
            {
                System.IO.File.Delete(FullName);
                eventLog1.WriteEntry("In UploadFiles - " + ex.Message);
                localLog.WriteLog("Error", "In UploadFiles - " + FullName + ": " + ex.Message);
                return true;
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("In UploadFiles - " + ex.Message);
                localLog.WriteLog("Error", "In UploadFiles - " + FullName + ": " + ex.Message);
                return false;
            }
        }

        public Boolean validate(DataSet data, string[] Columns)
        {
            if (data == null) { return false; }
            if (data.Tables.Count <= 0) { return false; }
            foreach (string column in Columns)
                if (!data.Tables[0].Columns.Contains(column))
                {
                    localLog.WriteLog("Error", "Validate - Column not found" + column);
                    return false;
                };

            return true;
        }

        private string ColumnRange(string FileName)
        {
            string[] fileType = FileName.Split('_');
            if (fileType.Contains("MXQ")) return "$A1:R65535]";
            if (fileType.Contains("INV")) return "$A1:AO65535]";
            if (fileType.Contains("ISU")) return "$A1:AC65535]";
            if (fileType.Contains("NOP")) return "$A1:AU65535]";
            if (fileType.Contains("ORD")) return "$A1:T65535]";
            if (fileType.Contains("QOH")) return "$A1:D65535]";
            if (fileType.Contains("TRN")) return "$A1:H65535]";
            return "$A1:AU65535]";
        }

        public DataSet GetExcelData(string FileName, string SheetName, Boolean UseHeadersV)
        {
            try
            {
                //Ensure the file exists    
                if (!File.Exists(FileName))
                {                    
                    return null;
                }
                if (SheetName.Length <= 0)
                {
                    return null;
                }

                string strConnection = "Data Source=" + FileName + ";Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                if (FileName.ToUpper().Contains(".XLS"))
                {
                    strConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties='Excel 12.0 XML;HDR=Yes'";
                }
                if (FileName.ToUpper().Contains(".XLSB"))
                {
                    strConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties='Excel 12.0 XML;HDR=Yes'";
                }

                //if (UseHeaders == false) strConnection = strConnection.Replace("HDR=Yes", "HDR=No");

                string strSQL = "SELECT * FROM [" + SheetName + ColumnRange(FileName);   //"$A1:I65535]";

                var adp = new System.Data.OleDb.OleDbDataAdapter(strSQL, strConnection);
                var dat = new System.Data.DataSet();

                adp.Fill(dat);
                return dat;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
