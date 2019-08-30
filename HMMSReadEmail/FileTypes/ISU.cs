using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMMSReadEmail.FileType
{
    class ISUModel
    {
        public ISUModel() : base()
        {
            // Truncate the Table
            HMMSEntitiesDB isudb = new HMMSEntitiesDB();
            isudb.ISUCopytoHistory();
            var all = from c in isudb.ISUs select c;
            isudb.ISUs.RemoveRange(all);
            isudb.SaveChanges();
        }

        public string[] ISUlist =
        {
            "Unit Price",
            "Issue Point Code",
            "Date Out",
            "NSN",
            "Building Code",
            "Hazard Code",
            "Issue Group Sequence",
            "Issue QTY Out",
            "Scale Indicator",
            "UoM",
            "Item Name",
            "Memo/Note",
            "Job ID Code",
            "Weight Out (Kgrams)",
            "Kit Indicator",
            "Pounds Out QTY",
            "Supervisor Code",
            "MSDS Printed IND",
            "Serial Number",
            "Organization Code",
            "Product/MSDS Number",
            "ID Number",
            "Resource Name",
            "Status Out",
            "Trade Name",
            "Update Date",
            "Updated By",
            "Zone Code",
            "Resource Out Cd"
        };

        public Boolean loadData(DataSet dat)
        {
            HMMSEntitiesDB isudb = new HMMSEntitiesDB();
            try
            {
                foreach (DataRow dr in dat.Tables[0].Rows)
                {
                    ISU localisu = new ISU();
                    localisu.Id = Guid.NewGuid();
                    localisu.Unit_Price = Convert.IsDBNull(dr["Unit Price"]) ? "" : dr["Unit Price"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.Issue_Point_Code = Convert.IsDBNull(dr["Issue Point Code"]) ? "" : dr["Issue Point Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.Date_Out = Convert.IsDBNull(dr["Date Out"]) ? "" : dr["Date Out"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.NSN = Convert.IsDBNull(dr["NSN"]) ? "" : dr["NSN"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.Building_Code = Convert.IsDBNull(dr["Building Code"]) ? "" : dr["Building Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.Hazard_Code = Convert.IsDBNull(dr["Hazard Code"]) ? "0" : dr["Hazard Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.Issue_Group_Sequence = Convert.IsDBNull(dr["Issue Group Sequence"]) ? "" : dr["Issue Group Sequence"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.Issue_QTY_Out = Convert.IsDBNull(dr["Issue QTY Out"]) ? "0" : dr["Issue QTY Out"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.Scale_Indicator = Convert.IsDBNull(dr["Scale Indicator"]) ? "0" : dr["Scale Indicator"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.UoM = Convert.IsDBNull(dr["UoM"]) ? "0" : dr["UoM"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.Item_Name = Convert.IsDBNull(dr["Item Name"]) ? "" : dr["Item Name"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.Memo_Note = Convert.IsDBNull(dr["Memo/Note"]) ? "" : dr["Memo/Note"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.Job_ID_Code = Convert.IsDBNull(dr["Job ID Code"]) ? "" : dr["Job ID Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.Weight_Out = Convert.IsDBNull(dr["Weight Out (Kgrams)"]) ? "0" : dr["Weight Out (Kgrams)"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.Kit_Indicator = Convert.IsDBNull(dr["Kit Indicator"]) ? "0" : dr["Kit Indicator"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.Pounds_Out_QTY = Convert.IsDBNull(dr["Pounds Out QTY"]) ? "0" : dr["Pounds Out QTY"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.Supervisor_Code = Convert.IsDBNull(dr["Supervisor Code"]) ? "" : dr["Supervisor Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.MSDS_Printed_IND = Convert.IsDBNull(dr["MSDS Printed IND"]) ? "0" : dr["MSDS Printed IND"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.Serial_Number = Convert.IsDBNull(dr["Serial Number"]) ? "" : dr["Serial Number"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.Organization_Code = Convert.IsDBNull(dr["Organization Code"]) ? "" : dr["Organization Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.Product_MSDS_Number = Convert.IsDBNull(dr["Product/MSDS Number"]) ? "0" : dr["Product/MSDS Number"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.ID_Number = Convert.IsDBNull(dr["ID Number"]) ? "0" : dr["ID Number"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.Resource_Name = Convert.IsDBNull(dr["Resource Name"]) ? "" : dr["Resource Name"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.Status_Out = Convert.IsDBNull(dr["Status Out"]) ? "0" : dr["Status Out"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.Trade_Name = Convert.IsDBNull(dr["Trade Name"]) ? "" : dr["Trade Name"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.Update_Date = Convert.IsDBNull(dr["Update Date"]) ? "" : dr["Update Date"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.Updated_By = Convert.IsDBNull(dr["Updated By"]) ? "" : dr["Updated By"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.Zone_Code = Convert.IsDBNull(dr["Zone Code"]) ? "" : dr["Zone Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localisu.Resource_Out_Cd = Convert.IsDBNull(dr["Resource Out Cd"]) ? "" : dr["Resource Out Cd"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");

                    isudb.ISUs.Add(localisu);
                }
                isudb.SaveChanges();
            }
            catch (System.Data.Entity.Core.EntityException ee)
            {
                var msg = ee.Message;
                msg = ee.InnerException.Message;
                FileTypes.LogModel log = new FileTypes.LogModel();
                log.WriteLog("ERROR", msg);
                return false;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                {
                    string msg;
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        msg = "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:" + eve.Entry.Entity.GetType().Name + ":" + eve.Entry.State;
                        foreach (var ve in eve.ValidationErrors)
                        {
                            msg = "- Property: \"{0}\", Error: \"{1}\"" + ve.PropertyName + ":" + ve.ErrorMessage;
                            FileTypes.LogModel log = new FileTypes.LogModel();
                            log.WriteLog("ERROR", msg);
                        }
                    }
                    return false;
                }
            }
            finally
            {
                isudb.Dispose();
            }
            return true;
        }
    }
}