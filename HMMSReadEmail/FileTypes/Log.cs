using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMMSReadEmail.FileTypes
{
    class LogModel
    {
        public LogModel() : base()
        {
            
        }
        public void WriteLog(string status, string description)
        {
            HMMSEntitiesDB logdb = new HMMSEntitiesDB();
            try
            { 
                LOG localLog = new LOG();
                localLog.Id = Guid.NewGuid();
                localLog.Status = status;
                localLog.Description = description;
                localLog.Update_Date = DateTime.UtcNow;
                logdb.LOGs.Add(localLog);
                logdb.SaveChanges();
            }


            catch (System.Data.Entity.Core.EntityException ee)
            {
                var msg = ee.Message;
                msg = ee.InnerException.Message;
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
                }
            }
            finally
            {
                logdb.Dispose();
            }
        }
    }
}
