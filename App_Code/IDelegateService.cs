using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDelegateService" in both code and config file together.
[ServiceContract]
public interface IDelegateService
{
    

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetEmployeeName/{depID}", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
    List<WCFEmployee> GetEmployeeName(string depID);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/SetDelegate/{empId}/{start}/{end}/{remark}", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
    bool SetDelegate(string empId, string start, string end, string remark);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RelinquishEmployee/{empid}", ResponseFormat = WebMessageFormat.Json)]
    void RelinquishEmployee(string empid);


    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RelinquishStoreClerk/{empid}", ResponseFormat = WebMessageFormat.Json)]
    void RelinquishStoreClerk(string empid);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetDelegateEmp/{empId}", ResponseFormat = WebMessageFormat.Json)]
    WCFEmployee GetDelegateEmp(string empId);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetDelegateStoreClerk/{depId}", ResponseFormat = WebMessageFormat.Json)]
    WCFEmployee GetDelegateStoreClerk(string depId);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetStoreClerk", ResponseFormat = WebMessageFormat.Json)]
    List<WCFEmployee> GetStoreClerk();

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/SetSupervisorDelegate/{empId}/{start}/{end}/{remark}", ResponseFormat = WebMessageFormat.Json)]
    bool SetSupervisorDelegate(string empId, string start,
    string end, string remark);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetActiveDelegateByEmpId/{empId}", ResponseFormat = WebMessageFormat.Json)]
    WCFDelegateAuthority GetActiveDelegateByEmpId(string empId);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RetrieveDelegateEmployeeByEmpId/{empId}", ResponseFormat = WebMessageFormat.Json)]
    WCFEmployee RetrieveDelegateEmployeeByEmpId(string empId);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/SetDepartmentDelegate/{empId}/{start}/{end}/{remark}", ResponseFormat = WebMessageFormat.Json)]
    bool SetDepartmentDelegate(string empId, string start,
string end, string remark);




}
