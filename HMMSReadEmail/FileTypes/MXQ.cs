using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMMSReadEmail.FileType
{
    public partial class MXQModel
    {
        public MXQModel() : base()
        {
            // Truncate the Table
            HMMSEntitiesDB mxqdb = new HMMSEntitiesDB();
            mxqdb.MXQCopytoHistory();
            var all = from c in mxqdb.MXQs select c;
            mxqdb.MXQs.RemoveRange(all);
            mxqdb.SaveChanges();
        }

        public string[] MXQlist =
        {
            "Zone Code",
            "Zone Description",
            "Building Code",
            "NSN",
            "Trade Name",
            "Item Name",
            "Update Date",
            "ZQL"
        };

        public Boolean loadData(DataSet dat)
        {
            HMMSEntitiesDB mxqdb = new HMMSEntitiesDB();
            try
            {
                foreach (DataRow dr in dat.Tables[0].Rows)
                {
                    MXQ localmxq = new MXQ();
                    localmxq.Id = Guid.NewGuid();
                    localmxq.Zone_Code = Convert.IsDBNull(dr["Zone Code"]) ? "" : dr["Zone Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localmxq.Zone_Description = Convert.IsDBNull(dr["Zone Description"]) ? "" : dr["Zone Description"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localmxq.NSN = Convert.IsDBNull(dr["NSN"]) ? "" : dr["NSN"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localmxq.Item_Name = Convert.IsDBNull(dr["Item Name"]) ? "" : dr["Item Name"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localmxq.Trade_Name = Convert.IsDBNull(dr["Trade Name"]) ? "" : dr["Trade Name"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localmxq.Update_Date = Convert.IsDBNull(dr["Update Date"]) ? "" : dr["Update Date"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localmxq.ZQL = Convert.IsDBNull(dr["ZQL"]) ? "0" : dr["ZQL"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    mxqdb.MXQs.Add(localmxq);
                }
                mxqdb.SaveChanges();
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
                mxqdb.Dispose();
            }
            return true;
        }
    }
}
