using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMMSReadEmail.FileType
{
    class AULModel
    {
        public AULModel() : base()
        {
            // Truncate the Table
            HMMSEntitiesDB auldb = new HMMSEntitiesDB();
            auldb.AULCopytoHistory();
            var all = from c in auldb.AULs select c;
            auldb.AULs.RemoveRange(all);
            auldb.SaveChanges();
        }
        public string[] AULlist =
       {
            "Zone Code",
            "Zone Description",
            "NSN",
            "Item Name",
            "Trade Name",
            "Manufacturer Part Number",
            "Product/MSDS Number",
            "MSDS Prep Date",
            "Authorization Expiration Date",
            "Update Date",
            "Active",
            "CAGE Code",
            "Updated By",
            "Building Code",
            "Update Date 2",
            "Unit of Issue",
            "Specification Number",
            "Specification Type/Grade/Class"
        };


        public Boolean loadData(DataSet dat)
        {
            HMMSEntitiesDB auldb = new HMMSEntitiesDB();
            try
            {
                foreach (DataRow dr in dat.Tables[0].Rows)
                {
                    AUL localaul = new AUL();
                    localaul.Id = Guid.NewGuid();
                    localaul.Zone_Code = Convert.IsDBNull(dr["Zone Code"]) ? "" : dr["Zone Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localaul.Zone_Description = Convert.IsDBNull(dr["Zone Description"]) ? "" : dr["Zone Description"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localaul.NSN = Convert.IsDBNull(dr["NSN"]) ? "" : dr["NSN"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localaul.Item_Name = Convert.IsDBNull(dr["Item Name"]) ? "" : dr["Item Name"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localaul.Trade_Name = Convert.IsDBNull(dr["Trade Name"]) ? "" : dr["Trade Name"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localaul.Manufacturer_Part_Number = Convert.IsDBNull(dr["Manufacturer Part Number"]) ? "" : dr["Manufacturer Part Number"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localaul.Product_MSDS_Number = Convert.IsDBNull(dr["Product/MSDS Number"]) ? "" : dr["Product/MSDS Number"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localaul.MSDS_Prep_Date = Convert.IsDBNull(dr["MSDS Prep Date"]) ? "" : dr["MSDS Prep Date"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localaul.Authorization_Expiration_Date = Convert.IsDBNull(dr["Authorization Expiration Date"]) ? "" : dr["Authorization Expiration Date"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localaul.Update_Date = Convert.IsDBNull(dr["Update Date"]) ? "" : dr["Update Date"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localaul.Active = Convert.IsDBNull(dr["Active"]) ? "" : dr["Active"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localaul.CAGE_Code = Convert.IsDBNull(dr["CAGE Code"]) ? "" : dr["CAGE Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localaul.Updated_By = Convert.IsDBNull(dr["Updated By"]) ? "" : dr["Updated By"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localaul.Building_Code = Convert.IsDBNull(dr["Building Code"]) ? "" : dr["Building Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localaul.Update_Date_2 = Convert.IsDBNull(dr["Update Date 2"]) ? "" : dr["Update Date 2"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localaul.Unit_of_Issue = Convert.IsDBNull(dr["Unit of Issue"]) ? "0" : dr["Unit of Issue"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localaul.Specification_Number = Convert.IsDBNull(dr["Specification Number"]) ? "" : dr["Specification Number"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localaul.Specification_Type_Grade_Class = Convert.IsDBNull(dr["Specification Type/Grade/Class"]) ? "" : dr["Specification Type/Grade/Class"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");

                    auldb.AULs.Add(localaul);
                }
                auldb.SaveChanges();
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
                auldb.Dispose();
            }
            return true;
        }
    }
}
