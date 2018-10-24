using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdjustmentDAO
/// </summary>
public class AdjustmentDAO
{
     
    public AdjustmentDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /*
* JW's codes starts
*/
/// <summary>
///  return pending adjustment
/// </summary>
/// <param name="empID"></param>
/// <returns></returns>
    public static List<Adjustment> AdjustmentsPending(int empID)
    {
        Model entities = new Model();
        return entities.Adjustments.Where(x => x.Acknowledged_By == null && x.Employee_ID == empID).ToList<Adjustment>();
    }

    public static void AddAdjustment(Adjustment adj)
    {

        Model entities = new Model();
        entities.Adjustments.Add(adj);
        entities.SaveChanges();
    }

    public static void RemoveAdjustment(string itemNo, int empID, DateTime date)
    {
        Model entities = new Model();
        Adjustment adj = entities.Adjustments.Where(x => x.Item_No == itemNo && x.Employee_ID == empID && x.Raised_Date == date).First();
        entities.Adjustments.Remove(adj);
        entities.SaveChanges();
    }

    public static dynamic PendingAdjustmentsList(string role)
    {
        Model entities = new Model();
        if (role == "SuperVisor")
        {
            var res = (from a in entities.Adjustments
                       join b in entities.ItemCatalogs
                        on a.Item_No equals b.Item_No
                       join c in entities.Employees
                        on a.Employee_ID equals c.Employee_ID
                       where (a.Quantity * b.Price) < 250 && a.Acknowledged_By == null
                       select new
                       {
                           a.Item_No,
                           b.Description,
                           b.Unit_of_Measure,
                           a.Quantity,
                           a.Remarks,
                           c.Employee_Name,
                           b.Price,
                           totalValue = a.Quantity * b.Price,
                           a.Employee_ID,
                           a.Raised_Date
                       }).ToList();

            return res;
        }
        else
        {
            var res = (from a in entities.Adjustments
                       join b in entities.ItemCatalogs
                        on a.Item_No equals b.Item_No
                       join c in entities.Employees
                        on a.Employee_ID equals c.Employee_ID
                       where (a.Quantity * b.Price) >= 250 && a.Acknowledged_By == null
                       select new
                       {
                           a.Item_No,
                           b.Description,
                           b.Unit_of_Measure,
                           a.Quantity,
                           a.Remarks,
                           c.Employee_Name,
                           b.Price,
                           totalValue = a.Quantity * b.Price,
                           a.Employee_ID,
                           a.Raised_Date
                       }).ToList();

            return res;
        }
    }

    public static dynamic AcknowledgedAdjustmentsList()
    {
        Model entities = new Model();
        var res = (from a in entities.Adjustments
                   join b in entities.ItemCatalogs
                    on a.Item_No equals b.Item_No
                   join c in entities.Employees
                    on a.Employee_ID equals c.Employee_ID
                   where a.Acknowledged_By != null
                   select new
                   {
                       a.Item_No,
                       b.Description,
                       b.Unit_of_Measure,
                       a.Quantity,
                       a.Remarks,
                       c.Employee_Name,
                       b.Price,
                       totalValue = a.Quantity * b.Price,
                       a.Employee_ID,
                       a.Raised_Date,
                       a.Acknowledgement_Date

                   }).ToList();

        return res;
    }

   

    public static void AcknowledgeAdjustment(string itemNo, int empID,Adjustment adj)
    {
        Model entities = new Model();
        Adjustment adj1 = entities.Adjustments.Where(x => x.Item_No == itemNo && x.Employee_ID == empID && x.Raised_Date == adj.Raised_Date).First();
        adj1.Acknowledged_By = adj.Acknowledged_By;
        adj1.Acknowledgement_Date = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
        entities.SaveChanges();
    }
    /*
   * JW's codes ends
   */
}