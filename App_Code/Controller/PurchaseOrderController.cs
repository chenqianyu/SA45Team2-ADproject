using SA45Team02_SSIS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PurchaseOrderController
/// </summary>
public class PurchaseOrderController
{
    //PurchaseOrderDAO poDAO;
    //OrderDetailsDAO odDAO;
    //SupplierDAO supDAO;
    //ItemCatalogDAO icDAO;


    public PurchaseOrderController()
    {
       
       
    }

    /*
* Thin's codes starts
*/

    public static void ManualGeneratePurchaseOrder(List<TemporaryOrderItem> list)
    {
        Dictionary<string, List<TemporaryOrderItem>> supplier_OrderItemsList = new Dictionary<string, List<TemporaryOrderItem>>();
        foreach (TemporaryOrderItem oi in list)
        {
                if (supplier_OrderItemsList.ContainsKey(oi.supplierID))
                {
                supplier_OrderItemsList[oi.supplierID].Add(oi);
                }
            else
            {
                List<TemporaryOrderItem> tol = new List<TemporaryOrderItem>();
                tol.Add(oi);
                supplier_OrderItemsList[oi.supplierID] = tol;
            }
        }

        foreach (string key1 in supplier_OrderItemsList.Keys)
        {
            if (supplier_OrderItemsList[key1].Count != 0)
            {
                PurchaseOrder order = new PurchaseOrder
                {
                    Supplier_ID = key1,
                    Employee_ID = 1,
                    PO_Date = DateTime.Now,
                };

                PurchaseOrderDAO.CreatePO(order);
                foreach (TemporaryOrderItem item in supplier_OrderItemsList[key1])
                {
                    OrderDetail od = new OrderDetail();
                    od.PO_No = order.PO_No;
                    od.Item_No = item.ItemNo;
                    od.Ordered_Qty = item.Qty;
                    od.Delivered_Qty = item.Qty;

                    OrderDetailsDAO.InsertOrderDetail(od);
                    ItemCatalogDAO.UpdateOrdered_QtyInItemCatalog(od);
                }

               

            }
        }
    }

    public static void AutoGeneratePurchaseOrder()
    {

        List<ItemCatalog> itemCatalogList = new List<ItemCatalog>();
        List<Supplier> supplierList = SupplierDAO.GetAllSuppliers();
        Dictionary<string, List<ItemCatalog>> Pairs = new Dictionary<string, List<ItemCatalog>>();
        foreach(Supplier s in supplierList)
        {
            Pairs.Add(s.Supplier_ID, new List<ItemCatalog>());
        }
        List<ItemCatalog> orderDetailList = ItemCatalogDAO.RetrieveItemCatalogsList();
        foreach (ItemCatalog ic in orderDetailList)
        {
            int currentQty = (ic.Total_Qty - ic.Allocated_Qty)+ic.Ordered_Qty;
            if (currentQty < ic.Reorder_Lvl)
            {
                string key = SupplierDAO.GetSupplierByItemNo(ic.Item_No).Supplier_ID;
                
                if (Pairs.ContainsKey(key))
                {
                    itemCatalogList = Pairs[key];
                    itemCatalogList.Add(ic);
                    Pairs[key] = itemCatalogList;
                }else
                {
                    itemCatalogList.Add(ic);
                    Pairs.Add(key, itemCatalogList);
                }
            }
        }

        foreach (string key1 in Pairs.Keys)
        {
            if (Pairs[key1].Count!=0)
            {
                PurchaseOrder order = new PurchaseOrder
                {
                    Supplier_ID = key1,
                    Employee_ID = 1,
                    PO_Date = DateTime.Now,                 
                };

                PurchaseOrderDAO.CreatePO(order);
                foreach(ItemCatalog item in Pairs[key1])
                {
                    OrderDetail od = new OrderDetail();
                    od.PO_No = order.PO_No;
                    od.Item_No = item.Item_No;
                    od.Ordered_Qty = item.Reorder_Qty;
                    //od.Ordered_Qty = item.Reorder_Qty;
                    OrderDetailsDAO.InsertOrderDetail(od);
                }



            }
        }   
    }

    public static List<TemporaryOrderItem> UpdatePurchaseOrderList(List<TemporaryOrderItem> temp,string itemNo,string description,string supplierID, string supplierName, string qty)
    {
        
      
        foreach (TemporaryOrderItem od in temp)
        {
            if (od.ItemNo == itemNo)
            {
              
                od.ItemNo = itemNo;
                od.ItemDescription = description;
                od.SupplierID = supplierID;
                od.SupplierName = supplierName;
                od.Qty = Convert.ToInt32(qty);
                break;
            }
        }
       
        return temp;
    }


    /// <summary>
    /// remove items from po cart
    /// </summary>
    /// <param name="tempPOList">list that save temp orders</param>
    /// <param name="itemNo">item no to remove</param>
    /// <returns></returns>
    public static List<TemporaryOrderItem> RemoveItemFromPurchaseOrderList(List<TemporaryOrderItem> tempPOList, string itemNo)
    {
        TemporaryOrderItem itemToRemove = new TemporaryOrderItem();
        foreach (TemporaryOrderItem od in tempPOList)
        {
            if (od.ItemNo == itemNo)
            {
                itemToRemove = od;
                break;
                
            }
        }
        tempPOList.Remove(itemToRemove);
        return tempPOList;
    }

    /// <summary>
    /// This method generate purchase order based on the item quantity level in database
    /// If current qty is lower than reorder level, it will generate po
    /// But not save into database until user confirms
    /// </summary>
    /// <returns></returns>
    public static List<TemporaryOrderItem> CreateListForPurchaseOrder()
    {
        List<TemporaryOrderItem> temOrderList = new List<TemporaryOrderItem>();
        List<ItemCatalog> orderDetailList = ItemCatalogDAO.RetrieveItemCatalogsList();
        foreach (ItemCatalog ic in orderDetailList)
        {
            int currentQty = ic.Total_Qty - ic.Allocated_Qty;
            if (currentQty < ic.Reorder_Lvl)
            {
                
    
                TemporaryOrderItem temp = new TemporaryOrderItem();
                temp.ItemNo=ic.Item_No;
                temp.ItemDescription = ic.Description;
                temp.supplierID = SupplierDAO.GetSupplierByItemNo(ic.Item_No).Supplier_ID;
                temp.supplierName = SupplierDAO.GetSupplierByItemNo(ic.Item_No).Supplier_Name;
                temp.Qty = ic.Reorder_Lvl;

                temOrderList.Add(temp);
            }
        }
        
        return temOrderList;

     
    }

    /// <summary>
    /// retrieve all supplier list from database
    /// </summary>
    /// <returns></returns>
    public static List<Supplier> RetrieveSupplierList()
    {
        return SupplierDAO.GetAllSuppliers();
    }

    /// <summary>
    /// retrieve all item catalogs from database
    /// </summary>
    /// <returns></returns>
    public static List<ItemCatalog> RetrieveItemCatalogsList()
    {
        return ItemCatalogDAO.RetrieveItemCatalogsList();
    }


    /// <summary>
    /// returns the supplier who has first priority to supply that corresponding itemNo
    /// </summary>
    /// <param name="itemNo"></param>
    /// <returns></returns>
    public static Supplier GetSupplierByCatalogIDWithFirstPreferenceRank(string itemNo)
    {
        return SupplierDAO.GetSupplierByItemNo(itemNo);
    }

    /// <summary>
    /// return purchase orders that were made between these intervals
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <returns></returns>
    public static List<PurchaseOrder> RetrievePurchaseOrders(DateTime? startDate, DateTime? endDate)
    {
        if(startDate==null && endDate == null)
        {
            return PurchaseOrderDAO.RetrievePurchaseOrderList();
        }
        return PurchaseOrderDAO.RetrievePurchaseOrderByDate(startDate,endDate);
    }

    /// <summary>
    /// return supplier that has corresponding supplier Id
    /// </summary>
    /// <param name="supplierID"></param>
    /// <returns></returns>
    public static Supplier GetSuppliersBySupplierID(string supplierID)
    {
       
        return SupplierDAO.GetSupplierBySupplierID(supplierID);
    }


    /// <summary>
    /// return pending po list
    /// </summary>
    /// <returns></returns>
    public  static List<PurchaseOrder> RetrievePendingPOList()
    {
        return PurchaseOrderDAO.RetrievePendingPOList();
    }

    /*
* Thin's codes ends
*/

    /*
 * Yex's codes starts
 */
 /// <summary>
 /// return all PO lists
 /// </summary>
 /// <returns></returns>
    public static List<PurchaseOrder> RetrieveAllPOList()
    {
        return PurchaseOrderDAO.RetrieveAllPOList();
    }


   
    /// <summary>
    /// return rejected POList
    /// </summary>
    /// <returns></returns>
    public static List<PurchaseOrder> RetrieveRejectedPOList()
    {
        return PurchaseOrderDAO.RetrieveRejectedPOList();
    }

    /// <summary>
    /// return approved PO List
    /// </summary>
    /// <returns></returns>
    public static List<PurchaseOrder> RetrieveApprovedPOList()
    {
        return PurchaseOrderDAO.RetrieveApprovedPOList();
    }
  
    /// <summary>
    /// return order details that are belonged to PO
    /// </summary>
    /// <param name="PO"></param>
    /// <returns></returns>
    public static List<OrderDetailsView> RetrieveOrderDetailView(int PO)
    {
        return PurchaseOrderDAO.RetrieveOrderDetailView(PO);
    }

    /// <summary>
    /// return supplier name that will supply items in PO
    /// </summary>
    /// <param name="POId">purchase order number</param>
    /// <returns></returns>
    public static Supplier RetrieveSupplierByPOno(int POId)
    {
        PurchaseOrder po = PurchaseOrderDAO.RetrievePurchaseOrderByPO_NO(POId);
        Supplier s = SupplierDAO.GetSupplierBySupplierID(po.Supplier_ID);
        return s;
    }

    /// <summary>
    /// reject Purchase Order
    /// </summary>
    /// <param name="PONo"></param>
    public static void RejectPO(int PONo)
    {
        PurchaseOrderDAO.RejectPO(PONo);
    }


    /// <summary>
    /// approve purchase Order
    /// </summary>
    /// <param name="PONo"></param>
    public static void ApprovePO(int PONo)
    {
        PurchaseOrderDAO.ApprovePO(PONo);
    }


    /// <summary>
    /// search purchase order by Purchase Order Number
    /// </summary>
    /// <param name="purchaseOrderId"></param>
    /// <returns></returns>
    public static PurchaseOrder RetrievePurchaseOrderByPO_NO(int purchaseOrderId)
    {
        return PurchaseOrderDAO.RetrievePurchaseOrderByPO_NO(purchaseOrderId);

    }

    /// <summary>
    /// search Employee by Employee ID
    /// </summary>
    /// <param name="empID"></param>
    /// <returns></returns>
    public static Employee RetrieveEmployeeByEmployeeID(int empID)
    {
        return EmployeeDAO.RetrieveEmployeeByEmployeeID(empID);
    }
    /*
 * Yex's codes ends
 */
}

