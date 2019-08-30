using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMMSReadEmail.FileType
{
    class TRNModel
    {
        public TRNModel() : base()
        {
            // Truncate the Table
            HMMSEntitiesDB trndb = new HMMSEntitiesDB();
            trndb.TRNCopytoHistory();
            var all = from c in trndb.TRNs select c;
            trndb.TRNs.RemoveRange(all);
            trndb.SaveChanges();
        }

        public string[] TRNlist =
        {
           "Received Date",
            "Transfer Date",
            "Transfer From Issue Point",
            "Receiving Issue Point",
            "Serial Number",
            "Transfer User Logon",
            "Received User Logon"
        };

        public Boolean loadData(DataSet dat)
        {
            HMMSEntitiesDB trndb = new HMMSEntitiesDB();
            try
            {
                foreach (DataRow dr in dat.Tables[0].Rows)
                {
                    TRN localtrn = new TRN();
                    localtrn.Id = Guid.NewGuid();
                    localtrn.Received_Date = Convert.IsDBNull(dr["Received Date"]) ? "" : dr["Received Date"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localtrn.Transfer_Date = Convert.IsDBNull(dr["Transfer Date"]) ? "" : dr["Transfer Date"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localtrn.Transfer_From_Issue_Point = Convert.IsDBNull(dr["Transfer From Issue Point"]) ? "" : dr["Transfer From Issue Point"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localtrn.Receiving_Issue_Point = Convert.IsDBNull(dr["Receiving Issue Point"]) ? "" : dr["Receiving Issue Point"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localtrn.Serial_Number = Convert.IsDBNull(dr["Serial Number"]) ? "" : dr["Serial Number"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localtrn.Transfer_User_Logon = Convert.IsDBNull(dr["Transfer User Logon"]) ? "" : dr["Transfer User Logon"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localtrn.Received_User_Logon = Convert.IsDBNull(dr["Received User Logon"]) ? "" : dr["Received User Logon"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");

                    trndb.TRNs.Add(localtrn);
                }
                trndb.SaveChanges();
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
                trndb.Dispose();
            }
            return true;
        }
    }
}
