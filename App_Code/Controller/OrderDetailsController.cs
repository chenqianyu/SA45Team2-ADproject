using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderDetailsController
/// </summary>
public class OrderDetailsController
{
    PurchaseOrderDAO poDAO;
    OrderDetailsDAO odDAO;
    SupplierDAO supDAO;
    ItemCatalogDAO icDAO;
    public OrderDetailsController()
    {
        poDAO = new PurchaseOrderDAO();
        odDAO = new OrderDetailsDAO();
        supDAO = new SupplierDAO();
        icDAO = new ItemCatalogDAO();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    //ItemCatalog
    public List<ItemCatalog> RetrieveItemCatalogsList()
    {
        return ItemCatalogDAO.RetrieveItemCatalogsList();
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="itemNo"></param>
    /// <returns></returns>
    //ItemCatalog
    public ItemCatalog RetrieveItemCatalogsListByItemNo(string itemNo)
    {
        return ItemCatalogDAO.RetrieveItemCatalogByItemNo(itemNo);
    }
   
   
    /// <summary>
    /// 
    /// </summary>
    /// <param name="PO_No"></param>
    /// <returns></returns>
    //Purchase Order
    public PurchaseOrder RetrievePurchaseOrderByPO_NO(int PO_No)
    {
        return PurchaseOrderDAO.RetrievePurchaseOrderByPO_NO(PO_No);
    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="purchaseOrderId"></param>
    /// <returns></returns>
    //Order Details
    public List<OrderDetail> RetrieveOrderDetails(int purchaseOrderId)
    {
        return OrderDetailsDAO.RetrieveOrderDetails(purchaseOrderId);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="purchaseOrderId"></param>
    /// <param name="itemNo"></param>
    /// <returns></returns>

    //OrderDetails
    public List<OrderDetail> RetrieveOrderDetailsByItemNo(int purchaseOrderId, string itemNo)
    {
        return OrderDetailsDAO.RetrieveOrderDetailsByItemNo(purchaseOrderId, itemNo);

    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="supplierID"></param>
    /// <returns></returns>
    //Supplier
    public Supplier GetSupplierBySupplierID(string supplierID)
    {
        return SupplierDAO.GetSupplierBySupplierID(supplierID);
    }
}