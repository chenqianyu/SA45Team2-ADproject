using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRetrievalService" in both code and config file together.
[ServiceContract]
public interface IRetrievalService
{
  

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/AddRetrievalItemForUnfulfilled", ResponseFormat = WebMessageFormat.Json)]
    void AddRetrievalItemForUnfulfilled();

   
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RetrieveMaxID",ResponseFormat = WebMessageFormat.Json)]
    int RetrieveMaxID();

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/UpdateRetrieval/{retid}", ResponseFormat = WebMessageFormat.Json)]
    void UpdateRetrieval(string retid);


    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/AddNewRetrieval/{retid}", ResponseFormat = WebMessageFormat.Json)]
    void AddNewRetrieval(string retid);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetDisbursementViewByRetrievalID/{rtr}", ResponseFormat = WebMessageFormat.Json)]
    List<WCFDisbursementViewDTO> GetDisbursementViewByRetrievalID(string rtr);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetDisbursementViewByRetrievalIDAndItemNo/{rtr}/{itemno}", ResponseFormat = WebMessageFormat.Json)]
    List<WCFDisbursementViewDTO> GetDisbursementViewByRetrievalIDAndItemNo(string rtr, string itemno);


    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/getlist3/{rtr}", ResponseFormat = WebMessageFormat.Json)]
    List<WCFDisbursementViewDTO> Getlist3(string rtr);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/ReduceAllocatedQuantity/{itemno}/{adjustment}", ResponseFormat = WebMessageFormat.Json)]
    void ReduceAllocatedQuantity(string itemno, string adjustment);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/IncreaseAllocatedQuantity/{itemno}/{adjustment}", ResponseFormat = WebMessageFormat.Json)]
    void IncreaseAllocatedQuantity(string itemno, string adjustment);


    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetRequisitionNoByItemNoAndRetrievalID/{itemno}/{rtrid}", ResponseFormat = WebMessageFormat.Json)]
    List<int> GetRequisitionNoByItemNoAndRetrievalID(string itemno, string rtrid);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetRetrievalIDListLessThanMaxRetrievalId/{maxrtr}", ResponseFormat = WebMessageFormat.Json)]
    List<int> GetRetrievalIDListLessThanMaxRetrievalId(string maxrtr);


    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/AddAdjustment", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
     void AddAdjustment(string itemNo, string empID, string raisedDate, string remarks, string qty);

    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/ReduceItemTotalQty", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
    void ReduceItemTotalQty(List<DisbursementViewDTO> conflist);

    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/Reduceretrieval", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
    void Reduceretrieval(List<int> reqnos, int adjustment, string itemno, int maxrtrid);

    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/IncreaseRetrieval", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
   void IncreaseRetrieval(List<int> reqnos, int adjustment, string itemno, int maxrtrid);
}
