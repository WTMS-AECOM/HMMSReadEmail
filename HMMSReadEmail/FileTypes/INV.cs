using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMMSReadEmail.FileType
{
    class INVModel
    {
        public INVModel() : base()
        {
            // Truncate the Table
            HMMSEntitiesDB invdb = new HMMSEntitiesDB();
            invdb.INVCopytoHistory();
            var all = from c in invdb.INVs select c;
            invdb.INVs.RemoveRange(all);
            invdb.SaveChanges();
        }

        public string[] INVlist =
        {
           "CAGE Code",
            "Create Date",
            "Create Username",
            "Disposal Code",
            "Hazard Code",
            "UoM",
            "Memo",
            "Document Number Code",
            "Expiration Date",
            "Unit Price",
            "Lot/Batch Number",
            "Original Expiration Date",
            "Original Quantity",
            "Original UoM",
            "Product State Code",
            "Quantity",
            "Status",
            "Unit of Issue",
            "Issue Point Code",
            "Item Name",
            "Kit Description",
            "Kit ID Code",
            "Kit Indicator",
            "PNI",
            "Kit Price",
            "Manufacturer Kit Indicator",
            "Manufacturer Name",
            "Manufacturer Part Number",
            "NSN",
            "Product/MSDS Number",
            "Original Issuepoint Code",
            "Separable",
            "Serial Number",
            "Shelf/Bin",
            "Trade Name",
            "Update Date",
            "Updated By",
            "Zone Code",
            "Shelf Life Code",
            "Kgrams QTY",
            "Original Kgrams QTY"
        };

        public Boolean loadData(DataSet dat)
        {
            HMMSEntitiesDB invdb = new HMMSEntitiesDB();
            try
            {
                foreach (DataRow dr in dat.Tables[0].Rows)
                {
                    INV localinv = new INV();
                    localinv.Id = Guid.NewGuid();
                    localinv.CAGE_Code = Convert.IsDBNull(dr["CAGE Code"]) ? "" : dr["CAGE Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Create_Date = Convert.IsDBNull(dr["Create Date"]) ? "" : dr["Create Date"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Create_Username = Convert.IsDBNull(dr["Create Username"]) ? "" : dr["Create Username"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Disposal_Code = Convert.IsDBNull(dr["Disposal Code"]) ? "" : dr["Disposal Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Hazard_Code = Convert.IsDBNull(dr["Hazard Code"]) ? "0" : dr["Hazard Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.UoM = Convert.IsDBNull(dr["UoM"]) ? "" : dr["UoM"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Memo = Convert.IsDBNull(dr["Memo"]) ? "" : dr["Memo"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Document_Number_Code = Convert.IsDBNull(dr["Document Number Code"]) ? "" : dr["Document Number Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Expiration_Date = Convert.IsDBNull(dr["Expiration Date"]) ? "" : dr["Expiration Date"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Unit_Price = Convert.IsDBNull(dr["Unit Price"]) ? "" : dr["Unit Price"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Lot_Batch_Number = Convert.IsDBNull(dr["Lot/Batch Number"]) ? "" : dr["Lot/Batch Number"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Original_Expiration_Date = Convert.IsDBNull(dr["Original Expiration Date"]) ? "" : dr["Original Expiration Date"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Original_Quantity = Convert.IsDBNull(dr["Original Quantity"]) ? "" : dr["Original Quantity"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Original_UoM = Convert.IsDBNull(dr["Original UoM"]) ? "" : dr["Original UoM"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Product_State_Code = Convert.IsDBNull(dr["Product State Code"]) ? "0" : dr["Product State Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Quantity = Convert.IsDBNull(dr["Quantity"]) ? "" : dr["Quantity"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Status = Convert.IsDBNull(dr["Status"]) ? "0" : dr["Status"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Unit_of_Issue = Convert.IsDBNull(dr["Unit of Issue"]) ? "" : dr["Unit of Issue"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Issue_Point_Code = Convert.IsDBNull(dr["Issue Point Code"]) ? "0" : dr["Issue Point Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Item_Name = Convert.IsDBNull(dr["Item Name"]) ? "" : dr["Item Name"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Kit_Description = Convert.IsDBNull(dr["Kit Description"]) ? "" : dr["Kit Description"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Kit_ID_Code = Convert.IsDBNull(dr["Kit ID Code"]) ? "" : dr["Kit ID Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Kit_Indicator = Convert.IsDBNull(dr["Kit Indicator"]) ? "0" : dr["Kit Indicator"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.PNI = Convert.IsDBNull(dr["PNI"]) ? "0" : dr["PNI"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Kit_Price = Convert.IsDBNull(dr["Kit Price"]) ? "" : dr["Kit Price"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Manufacturer_Kit_Indicator = Convert.IsDBNull(dr["Manufacturer Kit Indicator"]) ? "" : dr["Manufacturer Kit Indicator"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Manufacturer_Name = Convert.IsDBNull(dr["Manufacturer Name"]) ? "" : dr["Manufacturer Name"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Manufacturer_Part_Number = Convert.IsDBNull(dr["Manufacturer Part Number"]) ? "" : dr["Manufacturer Part Number"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.NSN = Convert.IsDBNull(dr["NSN"]) ? "" : dr["NSN"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Product_MSDS_Number = Convert.IsDBNull(dr["Product/MSDS Number"]) ? "" : dr["Product/MSDS Number"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Original_Issuepoint_Code = Convert.IsDBNull(dr["Original Issuepoint Code"]) ? "" : dr["Original Issuepoint Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Separable = Convert.IsDBNull(dr["Separable"]) ? "0" : dr["Separable"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Serial_Number = Convert.IsDBNull(dr["Serial Number"]) ? "" : dr["Serial Number"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Shelf_Bin = Convert.IsDBNull(dr["Shelf/Bin"]) ? "" : dr["Shelf/Bin"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Trade_Name = Convert.IsDBNull(dr["Trade Name"]) ? "" : dr["Trade Name"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Update_Date = Convert.IsDBNull(dr["Update Date"]) ? "" : dr["Update Date"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Updated_By = Convert.IsDBNull(dr["Updated By"]) ? "" : dr["Updated By"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Zone_Code = Convert.IsDBNull(dr["Zone Code"]) ? "" : dr["Zone Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Shelf_Life_Code = Convert.IsDBNull(dr["Shelf Life Code"]) ? "" : dr["Shelf Life Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Kgrams_QTY = Convert.IsDBNull(dr["Kgrams QTY"]) ? "0" : dr["Kgrams QTY"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localinv.Original_Kgrams_QTY = Convert.IsDBNull(dr["Original Kgrams QTY"]) ? "" : dr["Original Kgrams QTY"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");

                    invdb.INVs.Add(localinv);
                }
                invdb.SaveChanges();
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
                invdb.Dispose();
            }
            return true;
        }
    }
}