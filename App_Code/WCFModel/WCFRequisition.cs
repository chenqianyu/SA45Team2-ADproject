using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WCFRequisition
/// </summary>
public class WCFRequisition
{

    int requisitionNo;
    int employeeID;
    string approvalTimestamp;
    string status;
    string submissionTimestamp;
    string remarks;

    public static WCFRequisition Make(int requisitionNo,int employeeID,string approvalTimestamp,
    string status, string submissionTimestamp,  string remarks )
    {
        WCFRequisition wcfReq = new WCFRequisition();
        wcfReq.RequisitionNo = requisitionNo;
        wcfReq.EmployeeID = employeeID;
        wcfReq.ApprovalTimestamp = approvalTimestamp;
        wcfReq.Status = status;
        wcfReq.SubmissionTimestamp = submissionTimestamp;
        wcfReq.Remarks = remarks;
        return wcfReq;
    }

    public int RequisitionNo
    {
        get
        {
            return requisitionNo;
        }

        set
        {
            requisitionNo = value;
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

    public string ApprovalTimestamp
    {
        get
        {
            return approvalTimestamp;
        }

        set
        {
            approvalTimestamp = value;
        }
    }

    public string Status
    {
        get
        {
            return status;
        }

        set
        {
            status = value;
        }
    }

    public string SubmissionTimestamp
    {
        get
        {
            return submissionTimestamp;
        }

        set
        {
            submissionTimestamp = value;
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

   
}