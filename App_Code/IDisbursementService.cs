using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDisbursementService" in both code and config file together.
[ServiceContract]
public interface IDisbursementService
{

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetDisbursementByDep/{depID}", ResponseFormat = WebMessageFormat.Json)]
    List<WCFDisbursementViewDTO> GetDisbursementByDep(string depID);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/UpdateDisbursementStatusAndDate/{depID}", ResponseFormat = WebMessageFormat.Json)]
    void UpdateDisbursementStatusAndDate(string depID);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/UpdateCompletedStatus", ResponseFormat = WebMessageFormat.Json)]
    void UpdateCompletedStatus();

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RetrieveDepartmentList", ResponseFormat = WebMessageFormat.Json)]
    List<WCFDepartment> RetrieveDepartmentList();

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetRepresentativeByDepartmentID/{depId}", ResponseFormat = WebMessageFormat.Json)]
    WCFEmployee GetRepresentativeByDepartmentID(string depId);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetEmployeeByEmpId/{empId}", ResponseFormat = WebMessageFormat.Json)]
    WCFEmployee GetEmployeeByEmpId(string empId);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RetrieveDeptByDepID/{id}", ResponseFormat = WebMessageFormat.Json)]
    WCFDepartment RetrieveDeptByDepID(string id);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/SelectDepartmentName", ResponseFormat = WebMessageFormat.Json)]
    List<string> SelectDepartmentName();

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/RetrieveInformation/{departmentName}", ResponseFormat = WebMessageFormat.Json)]
    WCFDisbursementItemView RetrieveInformation(string departmentName);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/Retrieveitem/{departmentName}", ResponseFormat = WebMessageFormat.Json)]
    List<WCFDataTable> Retrieveitem(string departmentName);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/FindItem/{item_name}", ResponseFormat = WebMessageFormat.Json)]
    string FindItem(string item_name);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/EditRetriveItem/{item_No}/{b}/{number}", ResponseFormat = WebMessageFormat.Json)]
    void EditRetriveItem(string item_No, string b, string number);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/ViewDisbursementIndex/{department}", ResponseFormat = WebMessageFormat.Json)]
    List<WCFDataTable> ViewDisbursementIndex(string department);


    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/ViewPastDisbursementItem/{departmentName}/{number}", ResponseFormat = WebMessageFormat.Json)]
    List<WCFDataTable> ViewPastDisbursementItem(string departmentName, string number);



}
