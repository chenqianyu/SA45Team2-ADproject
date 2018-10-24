using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPurchaseOrderService" in both code and config file together.
[ServiceContract]
public interface IPurchaseOrderService
{
   

    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/ManualGeneratePurchaseOrder", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
    void ManualGeneratePurchaseOrder(List<TemporaryOrderItem> list);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/AutoGeneratePurchaseOrder", ResponseFormat = WebMessageFormat.Json)]
    void AutoGeneratePurchaseOrder();

    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/UpdatePurchaseOrderList", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
    List<WCFTemporaryOrderItem> UpdatePurchaseOrderList(List<TemporaryOrderItem> temp, string itemNo, string description, string supplierID, string supplierName, string qty);

    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/RemoveItemFromPurchaseOrderList", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
    List<TemporaryOrderItem> RemoveItemFromPurchaseOrderList(List<TemporaryOrderItem> tempPOList, string itemNo);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/CreateListForPurchaseOrder", ResponseFormat = WebMessageFormat.Json)]
    List<TemporaryOrderItem> CreateListForPurchaseOrder();

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RetrieveSupplierList", ResponseFormat = WebMessageFormat.Json)]
    List<WCFSupplier> RetrieveSupplierList();

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RetrieveItemCatalogsList", ResponseFormat = WebMessageFormat.Json)]
    List<WCFItemCatalog> RetrieveItemCatalogsList();

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetSupplierByCatalogIDWithFirstPreferenceRank/{itemNo}", ResponseFormat = WebMessageFormat.Json)]
    WCFSupplier GetSupplierByCatalogIDWithFirstPreferenceRank(string itemNo);

    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/RetrievePurchaseOrders", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
    List<WCFPO> RetrievePurchaseOrders(string startDate, string endDate);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetSuppliersBySupplierID/{supplierID}", ResponseFormat = WebMessageFormat.Json)]
    WCFSupplier GetSuppliersBySupplierID(string supplierID);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RetrievePendingPOList", ResponseFormat = WebMessageFormat.Json)]
    List<WCFPO> RetrievePendingPOList();

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RetrieveOrderDetailView/{PO}", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
    List<WCFOrderDetailsView> RetrieveOrderDetailView(string PO);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RetrieveSupplierNameByPOno/{POId}", ResponseFormat = WebMessageFormat.Json)]
    WCFSupplier RetrieveSupplierNameByPOno(string POId);


    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RejectPO/{PONo}", ResponseFormat = WebMessageFormat.Json)]
    void RejectPO(string PONo);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/ApprovePO/{PONo}", ResponseFormat = WebMessageFormat.Json)]
    void ApprovePO(string PONo);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RetrieveAllPOList", ResponseFormat = WebMessageFormat.Json)]
    List<WCFPO> RetrieveAllPOList();

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RetrieveRejectedPOList", ResponseFormat = WebMessageFormat.Json)]
    List<WCFPO> RetrieveRejectedPOList();

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RetrieveApprovedPOList", ResponseFormat = WebMessageFormat.Json)]
    List<WCFPO> RetrieveApprovedPOList();

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RetrievePurchaseOrderByPO_NO/{purchaseOrderId}", ResponseFormat = WebMessageFormat.Json)]
    WCFPO RetrievePurchaseOrderByPO_NO(string purchaseOrderId);

    //[OperationContract]
    //[WebInvoke(Method = "GET", UriTemplate = "/RetrieveEmployeeByID/{employeeId}", ResponseFormat = WebMessageFormat.Json)]
    //WCFPO RetrieveEmployeeByID(string employeeId);




}


