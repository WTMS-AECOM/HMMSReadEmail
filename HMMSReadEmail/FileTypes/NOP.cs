using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMMSReadEmail.FileType
{
    class NOPModel
    {
        public NOPModel() : base()
        {
            // Truncate the Table
            HMMSEntitiesDB nopdb = new HMMSEntitiesDB();
            //nopdb.NOPCopytoHistory();
            var all = from c in nopdb.NOPs select c;
            nopdb.NOPs.RemoveRange(all);
            nopdb.SaveChanges();
        }

        public string[] NOPlist =
        {
           "Backorder Indicator",
            "CAGE Code",
            "Credit Card Code",
            "Delivery Destination",
            "Document Date",
            "Document Serial Number",
            "Issue Exception Code",
            "Issue Point Code",
            "Job Order Code",
            "Job Order Number",
            "JOCAS Number",
            "Manufacturer Serial Number",
            "NSN",
            "Order Activity",
            "Order Command Code",
            "Order Comments",
            "Order Completion Date",
            "Order Demand Code",
            "Order Document Number",
            "Order Fund Code",
            "Order Priority",
            "Order QTY",
            "Date Ordered",
            "Order Request Number",
            "Order Shop Code",
            "Order Unit of Issue",
            "Order Urgency",
            "Projected Delivery Code",
            "Projected Delivery Date",
            "Request Delete Date",
            "Request Status Code",
            "Requisistion Transaction Status Code",
            "Distribution Code",
            "Workorder Number/Ship To",
            "Ship to Location",
            "SRD",
            "Transaction Exception Code",
            "To Supply Date",
            "TRIC",
            "UJC",
            "Update Date",
            "Updated By",
            "Serial Number Count",
            "Requester Logon",
            "Work Order Code",
            "Work Unit Code",
            "Zone Code"
        };

        public Boolean loadData(DataSet dat)
        {
            HMMSEntitiesDB NOPdb = new HMMSEntitiesDB();
            try
            {
                foreach (DataRow dr in dat.Tables[0].Rows)
                {
                    NOP localnop = new NOP();
                    localnop.Id = Guid.NewGuid();
                    localnop.Backorder_Indicator = Convert.IsDBNull(dr["Backorder Indicator"]) ? "0" : dr["Backorder Indicator"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.CAGE_Code = Convert.IsDBNull(dr["CAGE Code"]) ? "" : dr["CAGE Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Credit_Card_Code = Convert.IsDBNull(dr["Credit Card Code"]) ? "" : dr["Credit Card Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Delivery_Destination = Convert.IsDBNull(dr["Delivery Destination"]) ? "" : dr["Delivery Destination"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Document_Date = Convert.IsDBNull(dr["Document Date"]) ? "1900" : dr["Document Date"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Document_Serial_Number = Convert.IsDBNull(dr["Document Serial Number"]) ? "" : dr["Document Serial Number"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Issue_Exception_Code = Convert.IsDBNull(dr["Issue Exception Code"]) ? "" : dr["Issue Exception Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Issue_Point_Code = Convert.IsDBNull(dr["Issue Point Code"]) ? "" : dr["Issue Point Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Job_Order_Code = Convert.IsDBNull(dr["Job Order Code"]) ? "" : dr["Job Order Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Job_Order_Number = Convert.IsDBNull(dr["Job Order Number"]) ? "" : dr["Job Order Number"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.JOCAS_Number = Convert.IsDBNull(dr["JOCAS Number"]) ? "" : dr["JOCAS Number"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Manufacturer_Serial_Number = Convert.IsDBNull(dr["Manufacturer Serial Number"]) ? "" : dr["Manufacturer Serial Number"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.NSN = Convert.IsDBNull(dr["NSN"]) ? "" : dr["NSN"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Order_Activity = Convert.IsDBNull(dr["Order Activity"]) ? "" : dr["Order Activity"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Order_Command_Code = Convert.IsDBNull(dr["Order Command Code"]) ? "" : dr["Order Command Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Order_Comments = Convert.IsDBNull(dr["Order Comments"]) ? "" : dr["Order Comments"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Order_Completion_Date = Convert.IsDBNull(dr["Order Completion Date"]) ? "" : dr["Order Completion Date"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Order_Demand_Code = Convert.IsDBNull(dr["Order Demand Code"]) ? "" : dr["Order Demand Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Order_Document_Number = Convert.IsDBNull(dr["Order Document Number"]) ? "" : dr["Order Document Number"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Order_Fund_Code = Convert.IsDBNull(dr["Order Fund Code"]) ? "" : dr["Order Fund Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Order_Priority = Convert.IsDBNull(dr["Order Priority"]) ? "0" : dr["Order Priority"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Order_QTY = Convert.IsDBNull(dr["Order QTY"]) ? "0" : dr["Order QTY"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Date_Ordered = Convert.IsDBNull(dr["Date Ordered"]) ? "" : dr["Date Ordered"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Order_Request_Number = Convert.IsDBNull(dr["Order Request Number"]) ? "" : dr["Order Request Number"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Order_Shop_Code = Convert.IsDBNull(dr["Order Shop Code"]) ? "" : dr["Order Shop Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Order_Unit_of_Issue = Convert.IsDBNull(dr["Order Unit of Issue"]) ? "0" : dr["Order Unit of Issue"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Order_Urgency = Convert.IsDBNull(dr["Order Urgency"]) ? "0" : dr["Order Urgency"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Projected_Delivery_Code = Convert.IsDBNull(dr["Projected Delivery Code"]) ? "" : dr["Projected Delivery Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Projected_Delivery_Date = Convert.IsDBNull(dr["Projected Delivery Date"]) ? "" : dr["Projected Delivery Date"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Request_Delete_Date = Convert.IsDBNull(dr["Request Delete Date"]) ? "" : dr["Request Delete Date"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Request_Status_Code = Convert.IsDBNull(dr["Request Status Code"]) ? "0" : dr["Request Status Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Requisistion_Transaction_Status_Code = Convert.IsDBNull(dr["Requisistion Transaction Status Code"]) ? "0" : dr["Requisistion Transaction Status Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Distribution_Code = Convert.IsDBNull(dr["Distribution Code"]) ? "" : dr["Distribution Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Workorder_Number_Ship_To = Convert.IsDBNull(dr["Workorder Number/Ship To"]) ? "" : dr["Workorder Number/Ship To"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Ship_to_Location = Convert.IsDBNull(dr["Ship to Location"]) ? "" : dr["Ship to Location"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.SRD = Convert.IsDBNull(dr["SRD"]) ? "" : dr["SRD"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Transaction_Exception_Code = Convert.IsDBNull(dr["Transaction Exception Code"]) ? "" : dr["Transaction Exception Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.To_Supply_Date = Convert.IsDBNull(dr["To Supply Date"]) ? "" : dr["To Supply Date"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.TRIC = Convert.IsDBNull(dr["TRIC"]) ? "" : dr["TRIC"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.UJC = Convert.IsDBNull(dr["UJC"]) ? "" : dr["UJC"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Update_Date = Convert.IsDBNull(dr["Update Date"]) ? "" : dr["Update Date"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Updated_By = Convert.IsDBNull(dr["Updated By"]) ? "" : dr["Updated By"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Serial_Number_Count = Convert.IsDBNull(dr["Serial Number Count"]) ? "" : dr["Serial Number Count"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Requester_Logon = Convert.IsDBNull(dr["Requester Logon"]) ? "" : dr["Requester Logon"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Work_Order_Code = Convert.IsDBNull(dr["Work Order Code"]) ? "" : dr["Work Order Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Work_Unit_Code = Convert.IsDBNull(dr["Work Unit Code"]) ? "" : dr["Work Unit Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");
                    localnop.Zone_Code = Convert.IsDBNull(dr["Zone Code"]) ? "" : dr["Zone Code"].ToString().Trim().Replace(">", "GTN").Replace("<", "ltn").Replace("$", "pct").Replace(",", ";").Replace("\n", ";").Replace("\r", ";").Replace("\"", "");

                    NOPdb.NOPs.Add(localnop);
                }
                NOPdb.SaveChanges();
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
                NOPdb.Dispose();
            }
            return true;
        }
    }
}
