using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderDetailsDAO
/// </summary>
public class OrderDetailsDAO
{
    public OrderDetailsDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    /*
* Thin's Codes Start
*/
    /// <summary>
    /// 
    /// </summary>
    /// <param name="orderDetail"></param>
    public static void InsertOrderDetail(OrderDetail orderDetail)
    {
        Model entities = new Model();

        entities.OrderDetails.Add(orderDetail);

        entities.SaveChanges();

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="purchaseOrderId"></param>
    /// <returns></returns>
    public static List<OrderDetail> RetrieveOrderDetails(int purchaseOrderId)
    {
        Model entities = new Model();
        List<OrderDetail> l;

        l = entities.OrderDetails.Where(x => x.PO_No == purchaseOrderId).ToList();
        return l;


    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="purchaseOrderId"></param>
    /// <param name="itemNo"></param>
    /// <returns></returns>
    public static List<OrderDetail> RetrieveOrderDetailsByItemNo(int purchaseOrderId, string itemNo)
    {
        Model entities = new Model();
        List<OrderDetail> l;

        l = entities.OrderDetails.Where(x => x.PO_No == purchaseOrderId && x.Item_No == itemNo).ToList();
        return l;


    }

    /*
* Thin's Codes Ends
*/

    /*
* JW's codes starts
*/
    public static OrderDetail GetOrderDetailsByPONoAndItemNo(int PONo, string ItemNo)
    {
        Model entities = new Model();
        return entities.OrderDetails.Where(x => x.PO_No == PONo && x.Item_No == ItemNo).First();
    }

    public static void UpdateDeliveredQty(OrderDetail order, int qty)
    {
        Model entities = new Model();
        order.Delivered_Qty = qty;
        entities.SaveChanges();
    }
    /*
* JW's codes ends
*/
}