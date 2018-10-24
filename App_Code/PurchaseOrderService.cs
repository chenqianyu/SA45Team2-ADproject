using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PurchaseOrderService" in code, svc and config file together.
public class PurchaseOrderService : IPurchaseOrderService
{
   

    public void ApprovePO(string PONo)
    {
        PurchaseOrderController.ApprovePO(Convert.ToInt32(PONo));
    }

    public void AutoGeneratePurchaseOrder()
    {
        PurchaseOrderController.AutoGeneratePurchaseOrder();
    }

    public List<TemporaryOrderItem> CreateListForPurchaseOrder()
    {
        return PurchaseOrderController.CreateListForPurchaseOrder();
    }

   

    public WCFSupplier GetSupplierByCatalogIDWithFirstPreferenceRank(string itemNo)
    {
        Supplier s = PurchaseOrderController.GetSupplierByCatalogIDWithFirstPreferenceRank(itemNo);
        WCFSupplier wcfSupplier=SupplierConverter.ChangeSupplierToWCFSupplier(s);
        return wcfSupplier;
    }

    public WCFSupplier GetSuppliersBySupplierID(string supplierID)
    {
        Supplier supplier = PurchaseOrderController.GetSuppliersBySupplierID(supplierID);
        WCFSupplier wcfSupplier=SupplierConverter.ChangeSupplierToWCFSupplier(supplier);
        return wcfSupplier;
    }

    public void ManualGeneratePurchaseOrder(List<TemporaryOrderItem> list)
    {
        PurchaseOrderController.ManualGeneratePurchaseOrder(list);
    }

    public void RejectPO(string PONo)
    {
        PurchaseOrderController.RejectPO(Convert.ToInt32(PONo));
    }

    public List<TemporaryOrderItem> RemoveItemFromPurchaseOrderList(List<TemporaryOrderItem> tempPOList, string itemNo)
    {

        return PurchaseOrderController.RemoveItemFromPurchaseOrderList(tempPOList,itemNo);
    }

    public List<WCFPO> RetrieveAllPOList()
    {
        List<PurchaseOrder> poList= PurchaseOrderController.RetrieveAllPOList();
         return PurchaseOrderConverter.ChangePOListToWCFPOList(poList);
     //   return null;
    }

    public List<WCFPO> RetrievePendingPOList()
    {
        List<PurchaseOrder> poList = PurchaseOrderController.RetrievePendingPOList();
      //  List<WCFPO> wcfPOList = PurchaseOrderConverter.ChangePOListToWCFPOList(poList);
        return PurchaseOrderConverter.ChangePOListToWCFPOList(poList); ;
    }


    public List<WCFPO> RetrieveApprovedPOList()
    {
        List<PurchaseOrder> poList = PurchaseOrderController.RetrieveApprovedPOList();
        return PurchaseOrderConverter.ChangePOListToWCFPOList(poList);
    }

    public List<WCFItemCatalog> RetrieveItemCatalogsList()
    {
       List<ItemCatalog> itemCatalogList= PurchaseOrderController.RetrieveItemCatalogsList();
       List<WCFItemCatalog> wcfItemCatalogList=ItemCatalogConverter.changeItemCatalogListToWCFItemCatalogList(itemCatalogList);
      
        return wcfItemCatalogList;
    }

    public List<WCFOrderDetailsView> RetrieveOrderDetailView(string PO)
    {
        List<OrderDetailsView> odvList=PurchaseOrderController.RetrieveOrderDetailView(Convert.ToInt32(PO));
        return OrderDetailsViewConverter.ChangevDTOListToWCFdvDTOList(odvList);
    }


    public WCFPO RetrievePurchaseOrderByPO_NO(string purchaseOrderId)
    {
      PurchaseOrder po=  PurchaseOrderController.RetrievePurchaseOrderByPO_NO(Convert.ToInt32(purchaseOrderId));
        return PurchaseOrderConverter.ChangePOToWCFPO(po);
    }

    public List<WCFPO> RetrievePurchaseOrders(string startDate, string endDate)
    {
       List<PurchaseOrder> poList= PurchaseOrderController.RetrievePurchaseOrders(Convert.ToDateTime(startDate), Convert.ToDateTime(endDate));
        return PurchaseOrderConverter.ChangePOListToWCFPOList(poList);
    }

    public List<WCFPO> RetrieveRejectedPOList()
    {
       List<PurchaseOrder> poList= PurchaseOrderController.RetrieveRejectedPOList();
        return PurchaseOrderConverter.ChangePOListToWCFPOList(poList);
    }

    public List<WCFSupplier> RetrieveSupplierList()
    {

        List<Supplier> list=PurchaseOrderController.RetrieveSupplierList();
        return SupplierConverter.ChangeSupplierListToWCFSupplierList(list);
    }

    public WCFSupplier RetrieveSupplierNameByPOno(string POId)
    {
        Supplier supplier= PurchaseOrderController.RetrieveSupplierByPOno(Convert.ToInt32(POId));

        return SupplierConverter.ChangeSupplierToWCFSupplier(supplier);
    }

    public List<WCFTemporaryOrderItem> UpdatePurchaseOrderList(List<TemporaryOrderItem> temp, string itemNo, string description, string supplierID, string supplierName, string qty)
    {
        List<TemporaryOrderItem> list = PurchaseOrderController.UpdatePurchaseOrderList(temp, itemNo, description, supplierID, supplierName, qty);
        return TemporaryOrderItemConverter.ChangeTempOIListToWCFTempOIList(list);
    }


   //public WCFEmployee RetrieveEmployeeByID(string employeeId)
   // {

   // }










}
