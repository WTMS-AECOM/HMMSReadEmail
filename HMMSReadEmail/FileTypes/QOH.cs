using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMMSReadEmail.FileType
{
    public partial class QOHModel
    {
        public QOHModel() : base()
        {
            // Truncate the Table
            HMMSEntitiesDB qohdb = new HMMSEntitiesDB();
            //qohdb.QOHCopytoHistory();
            var all = from c in qohdb.QOHs select c;
            qohdb.QOHs.RemoveRange(all);
            qohdb.SaveChanges();
        }

        public string[] QOHlist =
        {
           "Issue Point Code",
            "NSN",
            "Serial Number",
            "Status"

        };

        public Boolean loadData(DataSet dat)
        {
            HMMSEntitiesDB qohdb = new HMMSEntitiesDB();
            try
            {                                                                                           
                foreach (DataRow dr in dat.Tables[0].Rows)
                {
                    QOH localqoh = new QOH();
                    localqoh.Id = Guid.NewGuid();
                    localqoh.Issue_Point_Code = Convert.IsDBNull(dr["Issue Point Code"]) ? "" : dr["Issue Point Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localqoh.NSN = Convert.IsDBNull(dr["NSN"]) ? "" : dr["NSN"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localqoh.Serial_Number = Convert.IsDBNull(dr["Serial Number"]) ? "" : dr["Serial Number"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localqoh.Status = Convert.IsDBNull(dr["Status"]) ? "0" : dr["Status"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");

                    qohdb.QOHs.Add(localqoh);
                }
                qohdb.SaveChanges();
            }
            catch (System.Data.Entity.Core.EntityException ee)
            {
                var msg = ee.Message;
                msg = ee.InnerException.Message;
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
                        }
                    }
                    return false;
                }
            }
            finally
            {
                qohdb.Dispose();
            }
            return true;
        }
    }
}
