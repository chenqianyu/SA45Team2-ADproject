using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRequisitionService" in both code and config file together.
[ServiceContract]
public interface IRequisitionService
{
    //[OperationContract]
    //[WebInvoke(Method = "GET", UriTemplate = "/ReqListByDept", ResponseFormat = WebMessageFormat.Json)]
    //List<WCFReqListView> ReqListByDept();

    //[OperationContract]
    //[WebInvoke(Method = "GET", UriTemplate = "/AllReqListByDept", ResponseFormat = WebMessageFormat.Json)]
    //List<WCFReqListView> AllReqListByDept();

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RequisitionDetails/{requisitionNumber}/{deptID}", ResponseFormat = WebMessageFormat.Json)]
    List<WCFReqDetailsView> RequisitionDetails(string requisitionNumber, string deptID);

    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/ApproveRequisitions", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
    void ApproveRequisitions(List<ReqListView> approvedList);

    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/RejectRequisitions", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
    void RejectRequisitions(List<ReqListView> rejectedList);

    //[OperationContract]
    //[WebInvoke(Method = "GET", UriTemplate = "/sendMailReject/{emailAddress}/{recipientName}", ResponseFormat = WebMessageFormat.Json)]
    //void SendMailReject(string emailAddress, string recipientName);

    //[OperationContract]
    //[WebInvoke(Method = "GET", UriTemplate = "/sendMailApprove/{emailAddress}/{recipientName}/{htmlTable}", ResponseFormat = WebMessageFormat.Json)]
    //void SendMailApprove(string emailAddress, string recipientName, string htmlTable);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RequesterDetails/{requisitionNumber}/{deptID}", ResponseFormat = WebMessageFormat.Json)]
    WCFReqListView RequesterDetails(string requisitionNumber, string deptID);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RequisitionStatus/{requisitionNumber}", ResponseFormat = WebMessageFormat.Json)]
    string RequisitionStatus(string requisitionNumber);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetEmployee/{rid}", ResponseFormat = WebMessageFormat.Json)]
    WCFEmployee GetEmployee(string rid);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetItemByIemNo/{itemNo}", ResponseFormat = WebMessageFormat.Json)]
    WCFItemCatalog GetItemByIemNo(string itemNo);

    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/GetDepartment", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
    WCFDepartment GetDepartment(Employee e);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetRequisitionItemsByReqID/{rqID}", ResponseFormat = WebMessageFormat.Json)]
    List<WCFRequisitionItem> GetRequisitionItemsByReqID(string rqID);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RetrieveRequisitionByDateWithAll/{startDate}/{endDate}", ResponseFormat = WebMessageFormat.Json)]
    List<WCFRequisition> RetrieveRequisitionByDateWithAll(string startDate, string endDate);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RetrieveApprovedRequisitionByDate/{startDate}/{endDate}", ResponseFormat = WebMessageFormat.Json)]
    List<WCFRequisition> RetrieveApprovedRequisitionByDate(string startDate, string endDate);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetDistinctItemCatalogsByCategory", ResponseFormat = WebMessageFormat.Json)]
    List<string> GetDistinctItemCatalogsByCategory();

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RetrieveItemCatalogsList", ResponseFormat = WebMessageFormat.Json)]
    List<WCFItemCatalog> RetrieveItemCatalogsList();

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RetrieveItemCatalogByCategoryID/{categoryID}", ResponseFormat = WebMessageFormat.Json)]
    List<WCFItemCatalog> RetrieveItemCatalogByCategoryID(string categoryID);

    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/FindItemCatalogFromGivenListByItemNo", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
    WCFItemCatalog FindItemCatalogFromGivenListByItemNo(List<ItemCatalog> a, string b);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RetrieveMaxReqNo", ResponseFormat = WebMessageFormat.Json)]
    WCFRequisition RetrieveMaxReqNo();

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetCountByReqNo", ResponseFormat = WebMessageFormat.Json)]
    int GetCountByReqNo();

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/AddRequisition/{reqno}/{empId}/{d}/{status}", ResponseFormat = WebMessageFormat.Json)]
    void AddRequisition(string reqno, string empId, string d, string status);

    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/AddRequisitionItems", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
    void AddRequisitionItems(List<SA45Team02_SSIS.ItemCatalog> b, int reqno);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetRequisitionByEmpID/{empid}", ResponseFormat = WebMessageFormat.Json)]
    List<WCFRequisition> GetRequisitionByEmpID(string empid);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetRequisitionByReqNo/{reqNo}", ResponseFormat = WebMessageFormat.Json)]
    void GetRequisitionByReqNo(string reqNo);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetRequisitionItems/{reqNo}",ResponseFormat = WebMessageFormat.Json)]
    void GetRequisitionItems(string reqNo);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetRequisitionRequestByReqNo/{reqNo}", ResponseFormat = WebMessageFormat.Json)]
    List<WCFRequisitionRequest> GetRequisitionRequestByReqNo(string reqNo);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/UpdateRequisitionItemsByReqNoAndItemNo/{itemNo}/{reqno}/{q}", ResponseFormat = WebMessageFormat.Json)]
    void UpdateRequisitionItemsByReqNoAndItemNo(string itemNo, string reqno, string q);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/DeleteRequisitionItemsByReqNoAndItemNo/{itemNo}/{reqNo}", ResponseFormat = WebMessageFormat.Json)]
    void DeleteRequisitionItemsByReqNoAndItemNo(string itemNo, string reqNo);

}
