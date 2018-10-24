using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WCFReqListView
/// </summary>
public class WCFReqListView
{
    int requisitionNumber;
    string employeeName;
    string employeeEmail;
    string approvalStatus;
    string remarks;
    int employeeID;
    string departmentID;

    public static WCFReqListView Make(int requisitionNumber,string employeeName,
    string employeeEmail,  string approvalStatus,string remarks, int employeeID,string departmentID)
    {
        WCFReqListView wcfReq = new WCFReqListView();
        wcfReq.RequisitionNumber = requisitionNumber;
        wcfReq.EmployeeName = employeeName;
        wcfReq.EmployeeEmail = employeeEmail;
        wcfReq.ApprovalStatus = approvalStatus;
        wcfReq.Remarks = remarks;
        wcfReq.EmployeeID = employeeID;
        wcfReq.DepartmentID = departmentID;
        return wcfReq;
    }

    public int RequisitionNumber
    {
        get
        {
            return requisitionNumber;
        }

        set
        {
            requisitionNumber = value;
        }
    }

    public string EmployeeName
    {
        get
        {
            return employeeName;
        }

        set
        {
            employeeName = value;
        }
    }

    public string EmployeeEmail
    {
        get
        {
            return employeeEmail;
        }

        set
        {
            employeeEmail = value;
        }
    }

    public string ApprovalStatus
    {
        get
        {
            return approvalStatus;
        }

        set
        {
            approvalStatus = value;
        }
    }

    public string Remarks
    {
        get
        {
            return remarks;
        }

        set
        {
            remarks = value;
        }
    }

    public int EmployeeID
    {
        get
        {
            return employeeID;
        }

        set
        {
            employeeID = value;
        }
    }

    public string DepartmentID
    {
        get
        {
            return departmentID;
        }

        set
        {
            departmentID = value;
        }
    }

    
}