using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DeliveryOrderController
/// </summary>
public class DeliveryOrderController
{

    //PurchaseOrderDAO poDAO;
    //OrderDetailsDAO odDAO;
    //ItemCatalogDAO icDAO;
    //AdjustmentDAO adjDAO;

    public DeliveryOrderController()
    {
       
        //
        // TODO: Add constructor logic here
        //
    }

    public static dynamic GetDeliveryOrderList()
    {
       return PurchaseOrderDAO.GetDeliveryOrderList();
    }

    public static dynamic GetDeliveryOrderDetailsList(int POID)
    {
        return PurchaseOrderDAO.GetDeliveryOrderDetailsList(POID);
    }

    public static OrderDetail GetOrderDetailsByPONoAndItemNo(int PONo, string ItemNo)
    {
        return OrderDetailsDAO.GetOrderDetailsByPONoAndItemNo(PONo, ItemNo);
    }

    public static void UpdateDeliveredQty(OrderDetail order, int qty)
    {
        OrderDetailsDAO.UpdateDeliveredQty(order, qty);
    }


    public static void UpdateDeliveryDate(PurchaseOrder PO)
    {
        PurchaseOrderDAO.UpdateDeliveryDate(PO);
    }


    public static ItemCatalog RetrieveItemCatalogByItemNo(string itemNo)
    {

        return ItemCatalogDAO.RetrieveItemCatalogByItemNo(itemNo);

    }

    public static void IncreaseInventory(ItemCatalog item, int addQty)
    {
        ItemCatalogDAO.IncreaseInventory(item, addQty);
    }

    //public void DecreaseInventory(ItemCatalog item, int deductQty)
    //{
    //    icDAO.DecreaseInventory(item, deductQty);
    //}

    public static PurchaseOrder RetrievePurchaseOrderByPO_NO(int PO_No)
    {

        return PurchaseOrderDAO.RetrievePurchaseOrderByPO_NO(PO_No);

    }

    public static void AddAdjustment(string itemNo, int empID, DateTime raisedDate, string remarks, int qty)
    {
        Adjustment ad = new Adjustment();
        ad.Item_No = itemNo;
        ad.Employee_ID = empID;
        ad.Raised_Date = raisedDate;
        ad.Remarks = remarks;
        ad.Quantity = qty;
        AdjustmentDAO.AddAdjustment(ad);
    }

    public static dynamic GetPastDeliveryOrderList()
    {
        return PurchaseOrderDAO.GetPastDeliveryOrderList();
    }

}