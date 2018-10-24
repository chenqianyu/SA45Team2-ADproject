using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PurchaseOrderDAO
/// </summary>
public class PurchaseOrderDAO
{
    public PurchaseOrderDAO()
    {

    }
    /*
* Thin's Codes Start
*/
    /// <summary>
    /// 
    /// </summary>
    /// <param name="po"></param>
    public static void CreatePO(PurchaseOrder po)
    {
        Model entities = new Model();
        entities.PurchaseOrders.Add(po);
        entities.SaveChanges();

    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static List<PurchaseOrder> RetrievePurchaseOrderList()
    {
        Model entities = new Model();
        return entities.PurchaseOrders.OrderByDescending(x => x.PO_No).ToList();

    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <returns></returns>
    public static List<PurchaseOrder> RetrievePurchaseOrderByDate(DateTime? startDate, DateTime? endDate)
    {
        Model entities = new Model();
        return entities.PurchaseOrders
         .Where(m => m.PO_Date >= startDate && m.PO_Date <= endDate).ToList();




    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static List<PurchaseOrder> RetrievePendingPOList()
    {
        Model entities = new Model();
        return entities.PurchaseOrders.Where(x => x.Approval_Date == null).ToList();

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="PO_No"></param>
    /// <returns></returns>
    public static PurchaseOrder RetrievePurchaseOrderByPO_NO(int PO_No)
    {
        Model entities = new Model();
        return entities.PurchaseOrders.Where(x => x.PO_No == PO_No).ToList().First();

    }




    /*
* Thin's codes ends
*/
    /*
* Yex's codes starts
*/
    public static List<PurchaseOrder> RetrieveAllPOList()
    {
        using (Model entities = new Model())
        {
            return entities.PurchaseOrders.ToList();

        }
    }


    public static List<PurchaseOrder> RetrieveRejectedPOList()
    {
        using (Model entities = new Model())
        {
            return entities.PurchaseOrders.Where(x => x.Remarks == "Rejected").ToList();
        }

    }

    public static List<PurchaseOrder> RetrieveApprovedPOList()
    {
        using (Model entities = new Model())
        {
            return entities.PurchaseOrders.Where(x => x.Remarks == "Approved").ToList();
        }

    }


    /// <summary>
    /// RetrieveOrderDetailView By PO_NO
    /// </summary>
    /// <param name="PO"></param>
    /// <returns></returns>
    public static List<OrderDetailsView> RetrieveOrderDetailView(int PO_NO)
    {
        using (Model entites = new Model())
        {
            return entites.OrderDetailsViews.Where(x => x.PO_No == PO_NO).ToList();
        }
    }

    /// <summary>
    /// Reject PO
    /// </summary>
    /// <param name="PONo"></param>
    public static void RejectPO(int PONo)
    {
        Model entities = new Model();
        PurchaseOrder po = entities.PurchaseOrders.Where(x => x.PO_No == PONo).ToList().First();
        po.Remarks = Utility.Rejected;
        entities.SaveChanges();
    }

    /// <summary>
    /// Approve PO
    /// </summary>
    /// <param name="PONo"></param>
    public static void ApprovePO(int PONo)
    {
        Model entities = new Model();
        PurchaseOrder po = entities.PurchaseOrders.Where(x => x.PO_No == PONo).ToList().First();
        po.Remarks = Utility.Approved;
        po.Approval_Date = DateTime.Now;
        po.Approved_By = 1;

        entities.SaveChanges();
    }

    /*
* Yex's codes ends
*/

    /*
* JW's codes starts
*/


    public static void UpdateDeliveryDate(PurchaseOrder PO)
    {
        Model entities = new Model();
        PO.Actual_Delivery_Date = DateTime.Now;
        entities.SaveChanges();
    }

    public static dynamic GetDeliveryOrderList()
    {
        Model entities = new Model();
        var res = (from a in entities.PurchaseOrders
                   join x in entities.Suppliers
                    on a.Supplier_ID equals x.Supplier_ID
                   where a.Actual_Delivery_Date == null
                   select new
                   {
                       a.PO_No,
                       x.Supplier_Name,
                       a.PO_Date,
                       a.Expected_Delivery_Date
                   }).ToList();

        return res;
    }

    public static dynamic GetDeliveryOrderDetailsList(int POID)
    {
        Model entities = new Model();
        var res = (from a in entities.OrderDetails
                   join x in entities.ItemCatalogs
                    on a.Item_No equals x.Item_No
                   where a.PO_No == POID
                   select new
                   {
                       a.Item_No,
                       x.Category,
                       x.Description,
                       x.Unit_of_Measure,
                       a.Ordered_Qty,
                       a.Delivered_Qty,
                   }).ToList();

        return res;
    }

    public static dynamic GetPastDeliveryOrderList()
    {
        Model entities = new Model();
        var res = (from a in entities.PurchaseOrders
                   join x in entities.Suppliers
                    on a.Supplier_ID equals x.Supplier_ID
                   where a.Actual_Delivery_Date != null
                   select new
                   {
                       a.PO_No,
                       x.Supplier_Name,
                       a.PO_Date,
                       a.Actual_Delivery_Date
                   }).ToList();

        return res;
    }

    /*
* JW's codes ends
*/


}